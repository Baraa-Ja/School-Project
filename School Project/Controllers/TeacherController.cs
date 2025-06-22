using Microsoft.AspNetCore.Mvc;
using School_Project.Context;
using School_Project.Models;
using School_Project.Repositry;

namespace School_Project.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        // get List Of Teachers
        [HttpGet]
        public ActionResult Index()
        {
            List<Teacher> Teachherlist = _teacherRepository.GetAllTeachers();

            return View(Teachherlist);
        }
        // get the userinterface to add new Teacher
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }

        // Submit to create a Teacher
        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            _teacherRepository.Create(teacher);
            List<Teacher> Teachherlist = _teacherRepository.GetAllTeachers();

            return View("Index", Teachherlist);
        }


        public ActionResult Delete(int id)
        {
            _teacherRepository.Delete(id);
            List<Teacher> Teachherlist = _teacherRepository.GetAllTeachers();

            return View("Index", Teachherlist);
        }
    }
}
