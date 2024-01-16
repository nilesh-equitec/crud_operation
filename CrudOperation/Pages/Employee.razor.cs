using CrudOperation.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrudOperation.Pages
{
    public partial class Employee
    {
        private List<AllEmployeeResult>? employees;
        [Inject]
        private NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            employees = await services.GetAll(1);
        }
        private void UpdateEmployee(int id) {
            NavigationManager.NavigateTo($"/update/{id}");
        }
        private async void DeleteEmployee(int id)
        {
            await services.DeleteEmployee(id, 0);
            NavigationManager.NavigateTo(NavigationManager.Uri , forceLoad: true);
        }
      

    }
}
