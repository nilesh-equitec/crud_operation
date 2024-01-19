using CrudOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudOperation.Data.Repository
{
    public class EmployeeRepo
    {
        private readonly EmployeeDBContext _dbContext;
        public EmployeeRepo(EmployeeDBContext dBContext)
        {
            this._dbContext = dBContext;
        }

        public async Task<List<GetAllEmployeesResult>> GetAllEmployees(int value)
        {
            return await _dbContext.Procedures.GetAllEmployeesAsync(value);
        }
        public async Task<List<GetAllEmployeesWithSkillsResult>> GetAllEmployeesWithSkill(int id)
        {
            return await _dbContext.Procedures.GetAllEmployeesWithSkillsAsync(id);
        }

        public async Task<List<AllSkillsResult>> GetAllSkill()
        {
            return await _dbContext.Procedures.AllSkillsAsync();
        }

        public async Task<int> DelectEmployee1(int id, int value)
        {
            return await _dbContext.Procedures.DelectEmployee1Async(id, value);
        }

        public async Task<int> InsertEmployee(int value)
        {
            return await _dbContext.Procedures.InsertEmployeeWithSkillsAsync(value);
        }

        public async Task<int> InsertEmployee1(string Name, string Email, string Phone, string Gender, string adderess)
        {
            return await _dbContext.Procedures.InsertEmployeeAsync(Name, Email, Phone, Gender, adderess);
        }
        public async Task<int> InsertSkill(string skill)
        {
            return await _dbContext.Procedures.InsertSkillAsync(skill);
        }
        public async Task<int> InsertEmployeeWithSkill(int emp_id, int skill_id)
        {
            return await _dbContext.Procedures.InsertEmployeeSkillsAsync(emp_id, skill_id);
        }
        public async Task<int?> GetEmployeeByNameAsync1(string email, string phone)
        {
            int? userId = await _dbContext.Employees
              .Where(e => e.Email == email && e.Phone == phone)
              .Select(e => (int?)e.Id)
              .FirstOrDefaultAsync();
            return userId;
        }

        public async Task<SelectById1Result> SelectById(int id) { 
        
           return await _dbContext.Procedures.SelectById1Async(id);
        }
        public async Task<int> UpdateEmployee(int id , string name,string email, string phone, string gender , string address) {
            return await _dbContext.Procedures.UpdateEmployeAsync(id,name,email,phone,gender,address);
        }
    }
}
