using CrudOperation.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;

namespace CrudOperation.Pages
{
    public partial class UpdateForm
    {
        [Parameter]
        public int Id { get; set; }

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
            editContext = new(model);
            StateHasChanged();
            skills = await service.GetSkill();
            employee = await service.SelectById1Result(Id);
        }
        public async void SaveButton()
        {
            await service.UpdateEmploye(employee);
            await service.InsertEmployee(employee.ID);

          //  var user_id = await service.GetEmployeeByNameservice(model.email, model.phone);
            foreach (var item in CheckSkill)
            {
                await service.InsertEmployeeWithSkill(employee.ID, item);
            }
            NavigationManager?.NavigateTo($"/updateEmployee");
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


    }
}

