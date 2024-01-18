
using CrudOperation.Data.Repository;
using CrudOperation.Models;

namespace CrudOperation.Data.Service
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly EmployeeRepo _employeeRepo;
        public EmployeeService(EmployeeRepo employeeRepo)
        {
            this._employeeRepo = employeeRepo;
        }

        public async Task<int> DelectEmployee1(int id, int value)
        {
            return await _employeeRepo.DelectEmployee1(id,value);
        }

        public async Task<List<GetAllEmployeesResult>> GetAllEmployee()
        {
            return await _employeeRepo.GetAllEmployees();
        }
        
        public async Task<List<GetAllEmployeesWithSkillsResult>> GetAllSkill(int id)
        {
            return await _employeeRepo.GetAllEmployeesWithSkill(id);
        }

        public async Task<int> GetEmployeeByNameservice(string email, string phone)
        {
            return (int)await _employeeRepo.GetEmployeeByNameAsync1(email, phone);
        }

        public async Task<List<AllSkillsResult>> GetSkill()
        {
            return await _employeeRepo.GetAllSkill();
        }

        public async Task<int> InsertEmployee(GetAllEmployeesResult emp, AllSkillsResult skill)
        {
            return await _employeeRepo.InsertEmployee(emp,skill);
        }

        public async Task<int> InsertEmployee1(GetAllEmployeesResult emp)
        {
            return await _employeeRepo.InsertEmployee1(emp.name,emp.email,emp.phone,emp.gender,emp.address);
        }

        public async Task<int> InsertEmployeeWithSkill(int value1, int value2)
        {
            return await _employeeRepo.InsertEmployeeWithSkill(value1,value2);
        }

        public Task<int> InsertSkill(string skill)
        {
            return _employeeRepo.InsertSkill(skill);
        }
    
    }
}
