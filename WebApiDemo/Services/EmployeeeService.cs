using WebApiDemo.Models;
using WebApiDemo.Repositories;

namespace WebApiDemo.Services
{
    public class EmployeeeService:IEmployeeeService
    {
        private readonly IEmployeeeRepository repo;
        public EmployeeeService(IEmployeeeRepository repo)
        {
            this.repo = repo;
        }

        public int AddEmployeee(Employeee employeee)
        {
            return repo.AddEmployeee(employeee);
        }

        public int DeleteEmployeee(int id)
        {
            return repo.DeleteEmployeee(id);
        }

        public Employeee GetEmployeeeById(int id)
        {
            return repo.GetEmployeeeById(id);
        }

        public IEnumerable<Employeee> GetEmployeees()
        {
            return repo.GetEmployeees();
        }

        public int UpdateEmployeee(Employeee employeee)
        {
            return repo.UpdateEmployeee(employeee);
        }
    }
}
