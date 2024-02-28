using WebApiDemo.Models;

namespace WebApiDemo.Repositories
{
    public interface IEmployeeeRepository
    {
        IEnumerable<Employeee> GetEmployeees();
        Employeee GetEmployeeeById(int id);
        int AddEmployeee(Employeee employeee);
        int UpdateEmployeee(Employeee employeee);
        int DeleteEmployeee(int id);
    }
}
