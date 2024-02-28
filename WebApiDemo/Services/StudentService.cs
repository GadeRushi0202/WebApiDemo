using WebApiDemo.Models;
using WebApiDemo.Repositories;

namespace WebApiDemo.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository repo;
        public StudentService(IStudentRepository repo)
        {
            this.repo = repo;
        }
        public int AddStudent(Student student)
        {
            return repo.AddStudent(student);
        }

        public int DeleteStudent(int id)
        {
            return repo.DeleteStudent(id);
        }

        public IEnumerable<Student> GetStudent()
        {
            return repo.GetStudent();
        }

        public Student GetStudentById(int id)
        {
            return repo.GetStudentById(id);
        }

        public int UpdateStudent(Student student)
        {
            return repo.UpdateStudent(student);
        }
    }
}
