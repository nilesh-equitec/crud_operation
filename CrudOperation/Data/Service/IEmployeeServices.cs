using CrudOperation.Models;

namespace CrudOperation.Data.Service
{
    public interface IEmployeeServices
    {
        public Task<List<AllEmployeeResult>> GetAll(int? val);

        public  Task<int> CreateEmployee(Emp emp);

        public  Task<int>  UpdateEmployee(Emp emp);
        public Task<SelectById1Result> GetById(int id);
        public Task<int> DeleteEmployee(int? Id, int? value1);
    }
}
