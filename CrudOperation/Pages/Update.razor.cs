using CrudOperation.Models;
using Microsoft.AspNetCore.Components;

namespace CrudOperation.Pages
{
    public partial class Update
    {
        [Parameter]
        public int Id { get; set; }

        SelectById1Result employee=new SelectById1Result();

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            employee = await service.GetById(Id);
        }
        private Emp MapToEmployee(SelectById1Result result)
        {
            return new Emp
            {
                Id = result.id,
                Name = result.name,
                Email = result.email,
                Phone = result.phone,
                Address = result.address,
                Gender=result.gender,
                Skill=result.skill,
                Isactive=true,
            };
        }

        private async Task AddTask()
        {
            Emp emp=MapToEmployee(employee);
            await service.UpdateEmployee(emp);

            NavigationManager.NavigateTo($"/employeedata");
        }
    }
}
