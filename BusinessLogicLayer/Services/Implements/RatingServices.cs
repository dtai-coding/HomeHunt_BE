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
    public class RatingServices : IRatingServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public RatingServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Rating> GetRatings()
        {
            return _unitOfWork.Repository<Rating>().GetAll();

        }

        public async Task<Rating> GetRatingByIdAsync(Guid id)
        {
            return await _unitOfWork.Repository<Rating>().GetByIdGuid(id);
        }

        public async Task CreateRatingAsync(Rating rating)
        {
            await _unitOfWork.Repository<Rating>().InsertAsync(rating);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateRatingAsync(Rating rating)
        {
            await _unitOfWork.Repository<Rating>().UpdateGuid(rating, rating.Id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteRatingAsync(Guid id)
        {
            var rating = await _unitOfWork.Repository<Rating>().GetByIdGuid(id);
            if (rating != null)
            {
                _unitOfWork.Repository<Rating>().Delete(rating);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
