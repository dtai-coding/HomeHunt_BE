using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace BusinessLogicLayer.Services.Implements
{
    public class RoomApplicationServices : IRoomApplicationServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomApplicationServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<RoomApplication> GetRoomApplications()
        {
            return _unitOfWork.Repository<RoomApplication>().GetAll();

        }

        public async Task<RoomApplication> GetRoomApplicationByIdAsync(Guid id)
        {
            return await _unitOfWork.Repository<RoomApplication>().GetByIdGuid(id);
        }

        public async Task CreateRoomApplicationAsync(RoomApplication roomApplication)
        {
            await _unitOfWork.Repository<RoomApplication>().InsertAsync(roomApplication);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateRoomApplicationAsync(RoomApplication roomApplication)
        {
            await _unitOfWork.Repository<RoomApplication>().UpdateGuid(roomApplication, roomApplication.Id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteRoomApplicationAsync(Guid id)
        {
            var roomApplication = await _unitOfWork.Repository<RoomApplication>().GetByIdGuid(id);
            if (roomApplication != null)
            {
                _unitOfWork.Repository<RoomApplication>().Delete(roomApplication);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
