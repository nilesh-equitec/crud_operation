using CrudOperation.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CrudOperation.Pages
{
    public partial class AddEmployee
    {
      
        public string GenderMale = "Male";
        public string GenderFemale = "Female";
        public string skill1= "c";
        public string skill2 = "c++";
        public string skill3 = "java";
        public string skill4 = "c#";
        Emp model = new ();
        EditContext? editContext;
        [Inject]
        private NavigationManager? NavigationManager { get; set; }

        private Emp employee = new()
        {

            Skill ="c"
        };
        protected override void OnInitialized()
        {
            editContext = new(model);
            StateHasChanged();
        }

        private async Task AddTask()
        {
             await service.CreateEmployee(employee);

            NavigationManager?.NavigateTo($"/homepage");
        }
        private void ChangedButtonValue(string selectedValue)
        {
            employee.Gender = selectedValue;
        }
    }
}
