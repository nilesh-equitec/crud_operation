﻿using CrudOperation.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CrudOperation.Pages
{
    public partial class Employee
    {
        private List<GetAllEmployeesResult>? employees;

        private List<GetAllEmployeesWithSkillsResult>? _skills;

        public Dictionary<int,string> Result = new();
        [Inject]
        private NavigationManager? NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            employees = await services.GetAllEmployee();
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
        private async void DeleteEmployee(int id)
        {
            await services.DelectEmployee1(id, 0);
            NavigationManager?.NavigateTo(NavigationManager.Uri, forceLoad: true);
        }


    }
}
