using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Implements;
using BusinessLogicLayer.RequestModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Drawing;
using BusinessLogicLayer.ResponseModels;

namespace HomeHuntAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUsersService _userService;
        private readonly IAuthServices _authService;

		public UsersController(IUsersService userService, IAuthServices authServices)
		{
			_userService = userService;
			_authService = authServices;

        }

		// GET: api/Users
		[HttpGet]
		[Authorize]
		public ActionResult<IEnumerable<User>> GetUsers()
		{
			var users = _userService.GetUsers();
			return Ok(users);
		}

		// GET: api/Users/5
		[HttpGet("{id}")]
		[Authorize]
		public async Task<ActionResult<User>> GetUser(Guid id)
		{
			var user = await _userService.GetUserByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			return Ok(user);
		}

        [HttpGet("GetUserProfile/{id}")]
		[Authorize]
		public async Task<ActionResult<User>> GetUserProfile(Guid id)
        {
            try
            {
                var user = await _userService.GetUserProfile(id);
				return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

			// PUT: api/Users/5
		[HttpPut("{id}")]
		[Authorize]
		public async Task<IActionResult> PutUser(Guid id, UserUpdateRequestModel userModel)
		{
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
				if (user == null)
				{
					return NotFound(new { message = "User ID not found." });
				}

				user.Dob = userModel.Dob;
				user.Address = userModel.Address;
				user.PhoneNumber = userModel.PhoneNumber;		
				user.UpdatedDate = DateTime.Now;
				user.Gender = userModel.Gender;
				user.FullName = userModel.FullName;

				await _userService.UpdateUserAsync(user);

                return Ok(new { message = "User updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdatePassword")]
		[Authorize]
		public async Task<IActionResult> UpdatePassword(UpdatePasswordRequestModel request)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(request.UserId);
                if (user == null)
                {
                    return NotFound(new { message = "User ID not found." });
                }
				if(_authService.VerifyPassword(request.OldPassword, user.Password) == false)
				{
                    return BadRequest(new { message = "Password is uncorrect." });
                }

				string hashedPass = _authService.HashPassword(request.NewPassword);

                user.Password = hashedPass;

                await _userService.UpdateUserAsync(user);

                return Ok(new { message = "User Password updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Users
        [HttpPost]
		[Authorize]
		public async Task<ActionResult<User>> PostUser(UserCreateRequestModel userModel)
		{
			// Map properties from userModel to create a new user entity
			var user = new User
			{
				//Field = userModel.Field,
				FullName = userModel.FullName,
				Password = userModel.Password,
				Email = userModel.Email,
				Dob = userModel.Dob,
				Address = userModel.Address,
				PhoneNumber = userModel.PhoneNumber,
				RoleId = userModel.RoleId,
				Status = userModel.Status,
				CreatedDate = DateTime.Now,
				Gender = userModel.Gender
			};

			await _userService.CreateUserAsync(user);
			return CreatedAtAction("GetUser", new { id = user.Id }, user);
		}

		// DELETE: api/Users/5
		[HttpDelete("{id}")]
		[Authorize]
		public async Task<IActionResult> DeleteUser(Guid id)
		{
			var user = await _userService.GetUserByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			await _userService.DeleteUserAsync(id);
			return NoContent();
		}

		private async Task<bool> UserExists(Guid id)
		{
			return await _userService.UserExistsAsync(id);
		}
	}

}
