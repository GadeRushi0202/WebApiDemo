using WebApiDemo.Data;
using WebApiDemo.Models;

namespace WebApiDemo.Repositories
{
    public class EmployeeeRepository:IEmployeeeRepository
    {
       private readonly ApplicationDbContext db;
        public EmployeeeRepository(ApplicationDbContext db) // DI pattern inject dependency in constructor.
        {
            this.db = db;
        }

        public int AddEmployeee(Employeee employeee)
        {
            db.Employeees.Add(employeee);
            // SaveChages() reflect the changes from Dbset to DB
            int result = db.SaveChanges();
            return result;
        }

        public int DeleteEmployeee(int id)
        {
            int res = 0;
            var result = db.Employeees.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                db.Employeees.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }

        public Employeee GetEmployeeeById(int id)
        {
            var result = db.Employeees.Where(x => x.Id == id).SingleOrDefault();
            return result;
        }

        public IEnumerable<Employeee> GetEmployeees()
        {
            return db.Employeees.ToList();
        }

        public int UpdateEmployeee(Employeee employeee)
        {
            int res = 0;


            var result = db.Employeees.Where(x => x.Id == employeee.Id).FirstOrDefault();

            if (result != null)
            {
                result.Name = employeee.Name; // book contains new data, result contains old data
                result.Email = employeee.Email;
                result.Age = employeee.Age;
                result.Salary = employeee.Salary;

                res = db.SaveChanges();// update those changes in DB
            }

            return res;
        }
    }
}
