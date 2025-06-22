using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using School_Project.Models;
using School_Project.Repositry;

namespace School_Project.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courserepository;
        private readonly ITeacherRepository _teacherRepository;
        public CourseController(ICourseRepository courseRepository, ITeacherRepository teacherRepository)
        {
            _courserepository = courseRepository;
            _teacherRepository = teacherRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Course> stdlist = _courserepository.GetallCourses();

            return View(stdlist);
        }

        [HttpGet]
        public ViewResult Create()
        {
            List<Teacher> Teachherlist = _teacherRepository.GetAllTeachers();
            return View(Teachherlist);
        }


        [HttpPost]
        public ActionResult Create(Course course)
        {
            _courserepository.Create(course);
            List<Course> courseslist = _courserepository.GetallCourses();

            return View("Index", courseslist);
        }

        public ActionResult Delete(int id)
        {
            _courserepository.Delete(id);
            List<Course> courselist = _courserepository.GetallCourses();

            return View("Index", courselist);
        }
    }
}
