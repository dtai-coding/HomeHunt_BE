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
    public class HouseServices : IHouseServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public HouseServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<House> GetHouses()
        {
            return _unitOfWork.Repository<House>().GetAll();

        }

        public async Task<House> GetHouseByIdAsync(Guid id)
        {
            return await _unitOfWork.Repository<House>().GetByIdGuid(id);
        }

        public async Task CreateHouseAsync(House house)
        {
            await _unitOfWork.Repository<House>().InsertAsync(house);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateHouseAsync(House house)
        {
            await _unitOfWork.Repository<House>().UpdateGuid(house, house.Id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteHouseAsync(Guid id)
        {
            var house = await _unitOfWork.Repository<House>().GetByIdGuid(id);
            if (house != null)
            {
                _unitOfWork.Repository<House>().Delete(house);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
