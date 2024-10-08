using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IRatingServices
    {
        IEnumerable<Rating> GetRatings();
        Task<Rating> GetRatingByIdAsync(Guid id);
        Task CreateRatingAsync(Rating rating);
        Task UpdateRatingAsync(Rating rating);
        Task DeleteRatingAsync(Guid id);
    }
}
