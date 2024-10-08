using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Implements
{
    public class RoomServices : IRoomServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Room> GetRooms()
        {
            return _unitOfWork.Repository<Room>().GetAll();

        }

        public async Task<Room> GetRoomByIdAsync(Guid id)
        {
            return await _unitOfWork.Repository<Room>().GetByIdGuid(id);
        }

        public async Task CreateRoomAsync(Room room)
        {
            await _unitOfWork.Repository<Room>().InsertAsync(room);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateRoomAsync(Room room)
        {
            await _unitOfWork.Repository<Room>().UpdateGuid(room, room.Id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteRoomAsync(Guid id)
        {
            var room = await _unitOfWork.Repository<Room>().GetByIdGuid(id);
            if (room != null)
            {
                _unitOfWork.Repository<Room>().Delete(room);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
