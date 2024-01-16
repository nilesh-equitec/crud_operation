using CrudOperation.Models;

namespace CrudOperation.Data.Repository
{
    public class EmployeeRepo
    {
        private readonly EmployeeDBContext _dbContext;
        public EmployeeRepo(EmployeeDBContext dBContext)
        {
            this._dbContext = dBContext;
        }


        public async Task<List<AllEmployeeResult>> GetAllEmployeesAsync(int? value)
        {
            return await _dbContext.Procedures.AllEmployeeAsync(value);
        }

        public async Task<int> DeleteEmployeeAsync(int? Id, int? value1)
        {
            return await _dbContext.Procedures.DelectEmployee1Async(Id, value1);
        }

        public async Task<int> InsertEmployeeAsync(string Name, string Email, string Phone, string Gender, string Skill, string Address)
        {
            return await _dbContext.Procedures.InsertEmployeeAsync(Name, Email, Phone, Gender, Skill, Address);
        }

        public async Task<SelectById1Result> GetEmployeeByIdAsync(int? value)
        {
            return await _dbContext.Procedures.SelectById1Async(value);
        }

        public async Task<int> UpdateEmployeeAsync(int? Id, string Name, string Email, string Phone, string Address, string Skill)
        {
            return await _dbContext.Procedures.UpdateEmployeeAsync(Id, Name, Email, Phone, Address, Skill);

        }
    }
}
