using CrudOperation.Models;
using Microsoft.AspNetCore.Components;

namespace CrudOperation.Pages
{
    public partial class DeleteEmployee
    {
        private List<AllEmployeeResult>? employees;
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            employees = await services.GetAll(0);
        }
        private async void Delete(int id)
        {
            await services.DeleteEmployee(id, 1);
            NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }
    }
}
