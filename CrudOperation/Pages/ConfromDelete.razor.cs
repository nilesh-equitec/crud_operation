using CrudOperation.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;

namespace CrudOperation.Pages
{
    public partial class ConfromDelete
    {
        [Parameter]
        public int Id { get; set; }
        private List<GetAllEmployeesWithSkillsResult>? _selectSkills = new List<GetAllEmployeesWithSkillsResult>();
        private List<int>? _Skills;
        SelectById1Result employee = new SelectById1Result();
        public string GenderMale = "Male";
        public string GenderFemale = "Female";
        public List<AllSkillsResult> skills = new();
        public List<int> CheckSkill = new List<int>();
        GetAllEmployeesResult model = new();
        EditContext? editContext;
        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                editContext = new(model);
                StateHasChanged();
                skills = await service.GetSkill();
                employee = await service.SelectById1Result(Id);
                _selectSkills = await service.GetAllSkill(Id);
                _Skills = _selectSkills.Select(skill => skill.id).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async void SaveButton(int id)
        {
            try
            {
                await service.DelectEmployee1(id, 0);
                NavigationManager?.NavigateTo($"/deleteEmployee");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ChangedButtonValue(string selectedValue)
        {
            model.gender = selectedValue;
        }
        private void ChangedButton(int skillName)
        {
            if (CheckSkill.Contains(skillName))
            {
                CheckSkill.Remove(skillName);
            }
            else
            {
                CheckSkill.Add(skillName);
            }

        }
        private void OnCancelClicked() {
            NavigationManager?.NavigateTo($"/deleteEmployee");

        }
    }
}
