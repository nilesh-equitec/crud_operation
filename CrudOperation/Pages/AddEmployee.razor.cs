﻿using CrudOperation.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace CrudOperation.Pages
{
    public partial class AddEmployee
    {

        public string GenderMale = "Male";
        public string GenderFemale = "Female";
        public List<AllSkillsResult>  skills=new();
      //  public GetAllEmployeesResult employeesResult = new();
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
        public async void SaveButton() {
            if (model.name !=null && model.email != null && model.phone!=null && model.address!=null)
            {
                 await service.InsertEmployee1(model);
                var user_id = await service.GetEmployeeByNameservice(model.email, model.phone);
                foreach (var item in CheckSkill)
                {
                    await service.InsertEmployeeWithSkill(user_id, item);
                }
                NavigationManager?.NavigateTo($"/employeedata");
            }
            else {
             //   NavigationManager?.NavigateTo(NavigationManager.Uri, );
            }
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