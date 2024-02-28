using WebApiDemo.Data;
using WebApiDemo.Models;

namespace WebApiDemo.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext db;
        public StudentRepository(ApplicationDbContext db) // DI pattern inject dependency in constructor.
        {
            this.db = db;
        }
        public int AddStudent(Student student)
        {
            db.Students.Add(student);
            // SaveChages() reflect the changes from Dbset to DB
            int result = db.SaveChanges();
            return result;
        }

        public int DeleteStudent(int id)
        {
            int res = 0;
            var result = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                db.Students.Remove(result);
                res = db.SaveChanges();
            }
            return res; throw new NotImplementedException();
        }

        public IEnumerable<Student> GetStudent()
        {
            return db.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            var result = db.Students.Where(x => x.Id == id).SingleOrDefault();
            return result;
        }

        public int UpdateStudent(Student student)
        {
            int res = 0;


            var result = db.Students.Where(x => x.Id == student.Id).FirstOrDefault();

            if (result != null)
            {
                result.Name = student.Name; // book contains new data, result contains old data
                result.Percentage = student.Percentage;
                result.City = student.City;

                res = db.SaveChanges();// update those changes in DB
            }

            return res;
        }
    }
}
