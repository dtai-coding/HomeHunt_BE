using BusinessLogicLayer.RequestModels;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HomeHuntAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingServices _ratingServices;

        public RatingController(IRatingServices ratingServices)
        {
            _ratingServices = ratingServices;
        }

        // GET: api/Rating
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Rating>> GetRatings()
        {
            var ratings = _ratingServices.GetRatings();
            return Ok(ratings);
        }

        // GET: api/Rating/1
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Rating>> GetRating(Guid id)
        {
            var rating = await _ratingServices.GetRatingByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            return Ok(rating);
        }

        // POST: api/Ratings
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> AddRating(RatingCreateRequestModel ratingModel)
        {
            // Map properties from userModel to create a new user entity
            var rating = new Rating
            {
                //Field = userModel.Field,
                UserId = ratingModel.UserId,
                RoomId = ratingModel.UserId,
                Score = ratingModel.Score,
                Description = ratingModel.Description,
                Date = ratingModel.Date,
            };


            await _ratingServices.CreateRatingAsync(rating);
            return CreatedAtAction("GetRating", new { id = rating.Id }, rating);
        }

        // PUT: api/Ratings/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateRating(Guid id, RatingUpdateRequestModel ratingModel)
        {
            var rating = await _ratingServices.GetRatingByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            rating.UserId = ratingModel.UserId;
            rating.RoomId = ratingModel.UserId;
            rating.Score = ratingModel.Score;
            rating.Description = ratingModel.Description;
            rating.Date = ratingModel.Date;

            await _ratingServices.UpdateRatingAsync(rating);
            return NoContent();
        }



        // DELETE: api/Ratings/1
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteRating(Guid id)
        {
            var rating = await _ratingServices.GetRatingByIdAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            await _ratingServices.DeleteRatingAsync(id);
            return NoContent();
        }
    }
}
