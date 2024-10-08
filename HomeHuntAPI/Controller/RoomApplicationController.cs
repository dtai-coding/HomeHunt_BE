using BusinessLogicLayer.RequestModels;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeHuntAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomApplicationController : ControllerBase
    {
        private readonly IRoomApplicationServices _roomApplicationServices;

        public RoomApplicationController(IRoomApplicationServices roomApplicationServices)
        {
            _roomApplicationServices = roomApplicationServices;
        }

        // GET: api/RoomApplication
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<RoomApplication>> GetRoomApplications()
        {
            var roomApplications = _roomApplicationServices.GetRoomApplications();
            return Ok(roomApplications);
        }

        // GET: api/RoomApplication/1
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<RoomApplication>> GetRoomApplication(Guid id)
        {
            var roomApplication = await _roomApplicationServices.GetRoomApplicationByIdAsync(id);
            if (roomApplication == null)
            {
                return NotFound();
            }

            return Ok(roomApplication);
        }

        // POST: api/RoomApplications
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> AddRoomApplication(RoomApplicationCreateRequestModel roomApplicationModel)
        {
            // Map properties from userModel to create a new user entity
            var roomApplication = new RoomApplication
            {
                //Field = userModel.Field,
                FullName = roomApplicationModel.FullName,
                Dob = roomApplicationModel.Dob,
                Gender = roomApplicationModel.Gender,
                PhoneNumber = roomApplicationModel.PhoneNumber,
                Email = roomApplicationModel.Email,
                RoomId = roomApplicationModel.RoomId,
                UserId = roomApplicationModel.UserId,
            };


            await _roomApplicationServices.CreateRoomApplicationAsync(roomApplication);
            return CreatedAtAction("GetRoomApplication", new { id = roomApplication.Id }, roomApplication);
        }

        // PUT: api/RoomApplications/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateRoomApplication(Guid id, RoomApplicationUpdateRequestModel roomApplicationModel)
        {
            var roomApplication = await _roomApplicationServices.GetRoomApplicationByIdAsync(id);
            if (roomApplication == null)
            {
                return NotFound();
            }

            roomApplication.FullName = roomApplicationModel.FullName;
            roomApplication.Dob = roomApplicationModel.Dob;
            roomApplication.Gender = roomApplicationModel.Gender;
            roomApplication.PhoneNumber = roomApplicationModel.PhoneNumber;
            roomApplication.Email = roomApplicationModel.Email;
            roomApplication.RoomId = roomApplicationModel.RoomId;
            roomApplication.UserId = roomApplicationModel.UserId;

            await _roomApplicationServices.UpdateRoomApplicationAsync(roomApplication);
            return NoContent();
        }

        // DELETE: api/RoomApplications/1
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRoomApplication(Guid id)
        {
            var roomApplication = await _roomApplicationServices.GetRoomApplicationByIdAsync(id);
            if (roomApplication == null)
            {
                return NotFound();
            }

            await _roomApplicationServices.DeleteRoomApplicationAsync(id);
            return NoContent();
        }


    }
}
