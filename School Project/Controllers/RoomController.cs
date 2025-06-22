using Microsoft.AspNetCore.Mvc;
using School_Project.Models;
using School_Project.Repositry;

namespace School_Project.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        [HttpGet]
        public ActionResult Index()
        {
            List<Room> roomlist = _roomRepository.GetAllRooms();

            return View(roomlist);
        }

        [HttpGet]
        public ViewResult Create()
        {

            return View();
        }


        [HttpPost]
        public ActionResult Create(Room room)
        {
            _roomRepository.Create(room);
            List<Room> roomlist = _roomRepository.GetAllRooms();

            return View("Index",roomlist);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _roomRepository.Delete(id);
            List<Room> roomlist = _roomRepository.GetAllRooms();

            return View("Index",roomlist);
        }


    }
}
