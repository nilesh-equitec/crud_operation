using CrudOperation.Models;
using Microsoft.AspNetCore.Components;

namespace CrudOperation.Pages
{
    public partial class UpdateEmploye
    {
        private List<GetAllEmployeesResult>? employees;

        private List<GetAllEmployeesWithSkillsResult>? _skills;

        public Dictionary<int, string> Result = new();
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
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
        }
        private void UpdateEmployee(int id)
        {

            NavigationManager?.NavigateTo($"update/{id}");
        }


    }
}

