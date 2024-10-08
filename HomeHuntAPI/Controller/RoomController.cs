using BusinessLogicLayer.RequestModels;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeHuntAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomServices _roomServices;

        public RoomController(IRoomServices roomServices)
        {
            _roomServices = roomServices;
        }

        // GET: api/Room
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Room>> GetRooms()
        {
            var rooms = _roomServices.GetRooms();
            return Ok(rooms);
        }

        // GET: api/Room/1
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Room>> GetRoom(Guid id)
        {
            var room = await _roomServices.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // POST: api/Rooms
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> AddRoom(RoomCreateRequestModel roomModel)
        {
            // Map properties from userModel to create a new user entity
            var room = new Room
            {
                //Field = userModel.Field,
                Name = roomModel.Name,
                Rating = roomModel.Rating,
                Description = roomModel.Description,
                Length = roomModel.Length,
                Width = roomModel.Width,
                HouseId = roomModel.HouseId,
                Services = roomModel.Services,
            };


            await _roomServices.CreateRoomAsync(room);
            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // PUT: api/Rooms/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateRoom(Guid id, RoomUpdateRequestModel roomModel)
        {
            var room = await _roomServices.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            room.Name = roomModel.Name;
            room.Rating = roomModel.Rating;
            room.Description = roomModel.Description;
            room.Length = roomModel.Length;
            room.Width = roomModel.Width;
            room.HouseId = roomModel.HouseId;
            room.Services = roomModel.Services;

            await _roomServices.UpdateRoomAsync(room);
            return NoContent();
        }

        // DELETE: api/Rooms/1
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRoom(Guid id)
        {
            var room = await _roomServices.GetRoomByIdAsync(id);
            if (room == null)
            {
                return NotFound();
            }

            await _roomServices.DeleteRoomAsync(id);
            return NoContent();
        }


    }
}
