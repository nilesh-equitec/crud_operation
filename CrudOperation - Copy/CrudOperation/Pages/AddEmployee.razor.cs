using CrudOperation.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CrudOperation.Pages
{
    public partial class AddEmployee
    {

        public string GenderMale = "Male";
        public string GenderFemale = "Female";
        public List<AllSkillsResult>  skills=new List<AllSkillsResult>();
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
        }
        public async void AddTask() {
           await service.InsertEmployee1(model);
           var user_id = await service.GetEmployeeByNameservice(model.email, model.phone);
           foreach (var item in CheckSkill) {
                await service.InsertEmployeeWithSkill(user_id, item);
            }
            NavigationManager?.NavigateTo($"/employeedata");
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
            else { 
               CheckSkill.Add(skillName);
            }
          
        }


    }
}