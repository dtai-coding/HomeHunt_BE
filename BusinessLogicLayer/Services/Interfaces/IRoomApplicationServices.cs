using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IRoomApplicationServices
    {
        IEnumerable<RoomApplication> GetRoomApplications();
        Task<RoomApplication> GetRoomApplicationByIdAsync(Guid id);
        Task CreateRoomApplicationAsync(RoomApplication roomApplication);
        Task UpdateRoomApplicationAsync(RoomApplication roomApplication);
        Task DeleteRoomApplicationAsync(Guid id);
    }
}
