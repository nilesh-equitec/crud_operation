using CrudOperation.Models;
using Microsoft.AspNetCore.Components;

namespace CrudOperation.Pages
{
    public partial class DeleteEmploye
    {
        private List<GetAllEmployeesResult>? employees;

        private List<GetAllEmployeesWithSkillsResult>? _skills;
       
        public Dictionary<int, string> Result = new();
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                employees = await services.GetAllEmployee(1);
                foreach (var employee in employees)
                {
                    _skills = await services.GetAllSkill(employee.ID);

                     
                    foreach (var skill in _skills)
                    {
                        var userSkills = _skills
                                .Where(skill => skill.EmployeeId == employee.ID)
                                .Select(skill => skill.title);
                        Result[employee.ID] = string.Join(", ", userSkills);

                    }
                }
            }catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        private async void DeleteEmployee(int id)
        {
            try
            {
                //await services.DelectEmployee1(id, 0);
                NavigationManager?.NavigateTo($"/ConformDelete/{id}");
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}

