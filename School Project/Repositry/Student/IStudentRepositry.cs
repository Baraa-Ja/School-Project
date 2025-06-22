using School_Project.Models;

namespace School_Project.Repositry
{
    public interface IStudentRepositry
    {
        public List<Models.Student> GetAllStudents();
        public void Create(Models.Student student);
        public void Delete(int id);
        public void Register(int StudentID, int CourseID);
    }
}
