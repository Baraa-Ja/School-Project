using School_Project.Context;
using School_Project.Models;

namespace School_Project.Repositry
{
    public class StudnetRepositry : IStudentRepositry
    {
        private readonly MyDBContext _MydbContext;
        public StudnetRepositry(MyDBContext MydbContext)
        {
            _MydbContext = MydbContext;
        }
        public List<Student> GetAllStudents()
        {
            try
            {
                List<Student> students = (from stdobj in _MydbContext.Students select stdobj).ToList();

                return students;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public void Create(Student student)
        {
            _MydbContext.Students.Add(student);
            _MydbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Student Student = (from stdobj in _MydbContext.Students where stdobj.studentid == id select stdobj).FirstOrDefault();

            _MydbContext.Remove(Student);
            _MydbContext.SaveChanges();
        }

        public void Register(int StudentID, int CourseID)
        {
            StudenRegistrations studenRegistrations = new StudenRegistrations();
            studenRegistrations.Studentid = StudentID;
            studenRegistrations.Courseid = CourseID;

            _MydbContext.studentRegisterations.Add(studenRegistrations);
            _MydbContext.SaveChanges();
        }
    }
}
