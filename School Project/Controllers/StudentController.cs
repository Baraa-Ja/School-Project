using Microsoft.AspNetCore.Mvc;
using School_Project.Models;
using School_Project.Repositry;
using School_Project.Views.Models;

namespace School_Project.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepositry _studentRepositry;
        private readonly ICourseRepository _courseRepository;
        private readonly IWebHostEnvironment _environment;

        public StudentController(IStudentRepositry studentReposi, ICourseRepository courseRepository, IWebHostEnvironment hostingEnvironment)
        {
            _studentRepositry = studentReposi;
            _courseRepository = courseRepository;
            _environment = hostingEnvironment;
        }
        // get List Of students
        [HttpGet]
        public ActionResult Index()
        {
            List<Student> stdlist = _studentRepositry.GetAllStudents();

            return View(stdlist);
        }
        // get the userinterface to add new student
        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }

        // Submit to create a student
        [HttpPost]
        public ActionResult Create(Student Student, IFormFile StudentPhoto)
        {
            var wwRootPath = _environment.WebRootPath + "/StudentPictures/";
            Guid guid = Guid.NewGuid();
            string FullPath = System.IO.Path.Combine(wwRootPath, guid + StudentPhoto.FileName);

            using (var filestream = new FileStream(FullPath, FileMode.Create))
            {
                StudentPhoto.CopyTo(filestream);
            }

            Student.PhotoName = guid + StudentPhoto.FileName;
            _studentRepositry.Create(Student);
            List<Student> stdlist = _studentRepositry.GetAllStudents();
            return View("Index", stdlist);
        }


        public ActionResult Delete(int id)
        {
            _studentRepositry.Delete(id);
            List<Student> stdlist = _studentRepositry.GetAllStudents();
            return View("Index", stdlist);
        }

        [HttpGet]
        public ViewResult Register()
        {
            StudentViewModelcs data = new StudentViewModelcs();
            data.courses = _courseRepository.GetallCourses();
            data.Students = _studentRepositry.GetAllStudents();

            return View(data);
        }

        [HttpPost]
        public ActionResult Register(int studentid, int courseid)
        {
            _studentRepositry.Register(studentid, courseid);
            return RedirectToAction("Register");
        }
    }
}
