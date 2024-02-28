using WebApiDemo.Models;

namespace WebApiDemo.Services
{
    public interface IEmployeeeService
    {
        IEnumerable<Employeee> GetEmployeees();
        Employeee GetEmployeeeById(int id);
        int AddEmployeee(Employeee employeee);
        int UpdateEmployeee(Employeee employeee);
        int DeleteEmployeee(int id);
    }
}
