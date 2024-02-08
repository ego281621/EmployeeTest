using EmployeeTest.Data.Entities;

namespace EmployeeTest.Api.Data
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        Employee Create(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }

}