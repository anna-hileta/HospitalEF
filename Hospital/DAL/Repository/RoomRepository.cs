using Core.Abstractions.Repository;
using Core.Entities;

namespace DAL.Repository
{
    public class RoomRepository : BaseRepository<Room, int>, IRoomRepository
    {
        public RoomRepository(HospitalContext context) : base(context)
        {
        }
    }
}
