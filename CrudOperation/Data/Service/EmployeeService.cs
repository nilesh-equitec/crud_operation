
using CrudOperation.Data.Repository;
using CrudOperation.Models;

namespace CrudOperation.Data.Service
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly EmployeeRepo _employeeRepo;
        public EmployeeService(EmployeeRepo employeeRepo) { 
           this._employeeRepo = employeeRepo;
        }
        public async Task<List<AllEmployeeResult>> GetAll(int? val) {
            return await _employeeRepo.GetAllEmployeesAsync(val);
        }

        public async Task<int> CreateEmployee(Emp emp) { 

           return await _employeeRepo.InsertEmployeeAsync(emp.Name,emp.Email,emp.Phone,emp.Gender,emp.Skill,emp.Address);
        }

        public async Task<int> UpdateEmployee( Emp emp) {
            return await _employeeRepo.UpdateEmployeeAsync(emp.Id,emp.Name,emp.Email,emp.Phone,emp.Address,emp.Skill);
        }

        public async Task<int> DeleteEmployee(int? Id, int? value1) {

            return await _employeeRepo.DeleteEmployeeAsync(Id,value1);
        }

        public async Task<SelectById1Result> GetById(int id)
        {
           return await _employeeRepo.GetEmployeeByIdAsync(id);
        }
    }
}
