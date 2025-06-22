
using School_Project.Context;
using School_Project.Models;

namespace School_Project.Repositry
{
    public class RoomReposisotry : IRoomRepository
    {
        private MyDBContext _dbContext;

        public RoomReposisotry(MyDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Room room)
        {
            _dbContext.Add(room);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            if(id > 0)
            {
                Room Room = (from roomobj in _dbContext.Rooms where roomobj.Roomid == id select roomobj).FirstOrDefault();

                if (Room != null)
                {
                    _dbContext.Remove(Room);
                }

                _dbContext.SaveChanges();
            }
        }

        public List<Models.Room> GetAllRooms()
        {
             IEnumerable<Room> rooms = (from roomobj in _dbContext.Rooms select roomobj).ToList();

            return rooms.ToList();
        }
    }
}
