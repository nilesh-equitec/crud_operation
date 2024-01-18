using CrudOperation.Models;

namespace CrudOperation.Data.Service
{
    public interface IEmployeeServices
    {
        public Task<List<GetAllEmployeesResult>> GetAllEmployee();

        public Task<List<GetAllEmployeesWithSkillsResult>> GetAllSkill(int id);

        public Task<List<AllSkillsResult>> GetSkill();

        public Task<int> DelectEmployee1(int id, int value);

        public Task<int> InsertEmployee(GetAllEmployeesResult emp, AllSkillsResult skill);

        public Task<int> InsertEmployee1(GetAllEmployeesResult emp);

        public Task<int> InsertSkill(string skill);

        public Task<int> InsertEmployeeWithSkill(int value1, int value2);

        public Task<int> GetEmployeeByNameservice(string email, string phone);



    }
}
