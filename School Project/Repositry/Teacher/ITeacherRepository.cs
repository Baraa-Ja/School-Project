using School_Project.Models;

namespace School_Project.Repositry
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAllTeachers();
        public void Create(Teacher Teacher);
        public void Delete(int ID);
    }
}
