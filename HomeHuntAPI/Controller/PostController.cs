using BusinessLogicLayer.RequestModels;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeHuntAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostServices _postServices;

        public PostController(IPostServices postServices)
        {
            _postServices = postServices;
        }

        // GET: api/Post
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            var posts = _postServices.GetPosts();
            return Ok(posts);
        }

        // GET: api/Post/1
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Post>> GetPost(Guid id)
        {
            var post = await _postServices.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // POST: api/Posts
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<User>> AddPost(PostCreateRequestModel postModel)
        {
            // Map properties from userModel to create a new user entity
            var post = new Post
            {
                //Field = userModel.Field,
                RoomId = postModel.RoomId,
                Title = postModel.Title,
                Description = postModel.Description,
                ImageUrl = postModel.ImageUrl,
            };


            await _postServices.CreatePostAsync(post);
            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // PUT: api/Posts/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePost(Guid id, PostUpdateRequestModel postModel)
        {
            var post = await _postServices.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            post.RoomId = postModel.RoomId;
            post.Title = postModel.Title;
            post.Description = postModel.Description;
            post.ImageUrl = postModel.ImageUrl;

            await _postServices.UpdatePostAsync(post);
            return NoContent();
        }



        // DELETE: api/Posts/1
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePost(Guid id)
        {
            var post = await _postServices.GetPostByIdAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            await _postServices.DeletePostAsync(id);
            return NoContent();
        }
    }
}
