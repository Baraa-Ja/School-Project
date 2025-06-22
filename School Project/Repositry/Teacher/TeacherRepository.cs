using School_Project.Context;
using School_Project.Models;

namespace School_Project.Repositry
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyDBContext _myDBContext;

        public TeacherRepository(MyDBContext myDBContext)
        {
            _myDBContext = myDBContext;
        }

        public void Create(Teacher Teacher)
        {
            _myDBContext.Add(Teacher);
            _myDBContext.SaveChanges();
        }

        public void Delete(int ID)
        {
            if (ID > 0)
            {
                Teacher Teacher = (from teacherobj in _myDBContext.Teachers
                                   where teacherobj.Teacherid == ID
                                   select teacherobj).FirstOrDefault();

                if (Teacher != null)
                    _myDBContext.Remove(Teacher);
            }
            _myDBContext.SaveChanges();
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = (from teacherobj in _myDBContext.Teachers select teacherobj).ToList();
            return teachers;

        }
    }
}
