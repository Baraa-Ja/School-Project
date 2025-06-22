using School_Project.Models;

namespace School_Project.Repositry
{
    public interface IRoomRepository
    {
        public List<Models.Room> GetAllRooms();
        public void Create(Room room);
        public void Delete(int id);
    }
}
