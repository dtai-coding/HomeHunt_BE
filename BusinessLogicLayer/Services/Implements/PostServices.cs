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
    public class PostServices : IPostServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Post> GetPosts()
        {
            return _unitOfWork.Repository<Post>().GetAll();

        }

        public async Task<Post> GetPostByIdAsync(Guid id)
        {
            return await _unitOfWork.Repository<Post>().GetByIdGuid(id);
        }

        public async Task CreatePostAsync(Post post)
        {
            await _unitOfWork.Repository<Post>().InsertAsync(post);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdatePostAsync(Post post)
        {
            await _unitOfWork.Repository<Post>().UpdateGuid(post, post.Id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePostAsync(Guid id)
        {
            var post = await _unitOfWork.Repository<Post>().GetByIdGuid(id);
            if (post != null)
            {
                _unitOfWork.Repository<Post>().Delete(post);
                await _unitOfWork.CommitAsync();
            }
        }
    }
}
