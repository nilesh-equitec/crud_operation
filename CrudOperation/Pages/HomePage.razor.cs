using CrudOperation.Models;
using Microsoft.AspNetCore.Components;

namespace CrudOperation.Pages
{
    public partial class HomePage
    {
        [Parameter] public int EmployeeId { get; set; }
        SelectById1Result employee = new SelectById1Result();
        private async Task LoadEmployeeDetails()
        {
            employee= await  service.GetById(EmployeeId);
        }
        protected override async Task OnInitializedAsync()
        {
            // Call the method to load employee details when the component is initialized
            await LoadEmployeeDetails();
        }
    }
}
