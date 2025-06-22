using Microsoft.EntityFrameworkCore.Query;
using School_Project.Context;
using School_Project.Models;

namespace School_Project.Repositry
{
    public class CourseRepository : ICourseRepository
    {
        private readonly MyDBContext _dbContext;

        public CourseRepository(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(Models.Course course)
        {
            _dbContext.Add(course);
            _dbContext.SaveChanges();

        }

        public void Delete(int id)
        {
            if(id > 0)
            {
                Course course = (from courseobj in _dbContext.Courses where courseobj.Courseid == id select courseobj).FirstOrDefault();

                if(course != null)
                {
                    _dbContext.Remove(course);
                }

                _dbContext.SaveChanges();
            }
        }

        public List<Models.Course> GetallCourses()
        {
            List<Course> courses = (from courseobj in _dbContext.Courses select courseobj).ToList();
            return courses;
        }
    }
}
