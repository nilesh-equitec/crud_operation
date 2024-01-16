using CrudOperation.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CrudOperation.Pages
{
    public partial class AddEmployee
    {
        private String gender { get; set; }
        private bool IsFemale { get; set; }

        public string GenderMale = "Male";
        public string GenderFemale = "Female";
        Emp model = new ();
        EditContext? editContext;
        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private Emp employee=new Emp() { 
          
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

            NavigationManager.NavigateTo($"/homepage");
        }
        private void ChangedButtonValue(string selectedValue)
        {
            employee.Gender = selectedValue;
        }
    }
}
