using BusinessLogicLayer.RequestModels;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeHuntAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseServices _houseServices;

        public HouseController(IHouseServices houseServices)
        {
            _houseServices = houseServices;
        }

        // GET: api/House
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<House>> GetHouses()
        {
            var houses = _houseServices.GetHouses();
            return Ok(houses);
        }

        // GET: api/House/1
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<House>> GetHouse(Guid id)
        {
            var house = await _houseServices.GetHouseByIdAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            return Ok(house);
        }

        // POST: api/Houses
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> AddHouse(HouseCreateRequestModel houseModel)
        {
            // Map properties from userModel to create a new user entity
            var house = new House
            {
                //Field = userModel.Field,
                Address = houseModel.Address,
                Ward = houseModel.Ward,
                District = houseModel.District,
                City = houseModel.City,
            };


            await _houseServices.CreateHouseAsync(house);
            return CreatedAtAction("GetHouse", new { id = house.Id }, house);
        }

        // PUT: api/Houses/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateHouse(Guid id, HouseUpdateRequestModel houseModel)
        {
            var house = await _houseServices.GetHouseByIdAsync(id);
            if (house == null)
            {
                return NotFound(); 
            }

            house.Address = houseModel.Address;
            house.Ward = houseModel.Ward;
            house.District = houseModel.District;
            house.City = houseModel.City;

            await _houseServices.UpdateHouseAsync(house);
            return NoContent();
        }

        // DELETE: api/Houses/1
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteHouse(Guid id)
        {
            var house = await _houseServices.GetHouseByIdAsync(id);
            if (house == null)
            {
                return NotFound();
            }

            await _houseServices.DeleteHouseAsync(id);
            return NoContent();
        }


    }
}
