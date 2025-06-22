using School_Project.Models;

namespace School_Project.Repositry
{
    public interface ICourseRepository
    {
        public List<Models.Course> GetallCourses();
        public void Create(Models.Course course);
        public void Delete(int id);
    }
}
