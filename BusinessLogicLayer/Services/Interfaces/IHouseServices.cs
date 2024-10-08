using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IHouseServices
    {
        IEnumerable<House> GetHouses();
        Task<House> GetHouseByIdAsync(Guid id);
        Task CreateHouseAsync(House house);
        Task UpdateHouseAsync(House house);
        Task DeleteHouseAsync(Guid id);
    }
}
