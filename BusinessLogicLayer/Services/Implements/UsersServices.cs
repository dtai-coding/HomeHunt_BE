using DataAccessLayer.Models;
using DataAccessLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using BusinessLogicLayer.ResponseModels;

namespace BusinessLogicLayer.Services.Implements
{
	public class UsersServices : IUsersService
	{
		private readonly IUnitOfWork _unitOfWork;

		public UsersServices(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IEnumerable<User> GetUsers()
		{
			return _unitOfWork.Repository<User>().GetAll();

		}

		public async Task<User> GetUserByIdAsync(Guid id)
		{
			return await _unitOfWork.Repository<User>().GetByIdGuid(id);
		}

		public async Task CreateUserAsync(User user)
		{
			await _unitOfWork.Repository<User>().InsertAsync(user);
			await _unitOfWork.CommitAsync();
		}

		public async Task UpdateUserAsync(User user)
		{
			await _unitOfWork.Repository<User>().UpdateGuid(user, user.Id);
			await _unitOfWork.CommitAsync();
		}

		public async Task DeleteUserAsync(Guid id)
		{
			var user = await _unitOfWork.Repository<User>().GetByIdGuid(id);
			if (user != null)
			{
				_unitOfWork.Repository<User>().Delete(user);
				await _unitOfWork.CommitAsync();
			}
		}

        public async Task<bool> UserExistsAsync(Guid id)
		{
			var user = await _unitOfWork.Repository<User>().GetByIdGuid(id);
			return user != null;
		}

		public async Task<User> GetUserByFullNameAsync(string fullname)
		{
			// Truy vấn người dùng từ cơ sở dữ liệu theo tên người dùng
			var user = await _unitOfWork.Repository<User>()
				.GetAll()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.FullName == fullname);

			return user;
		}

		public async Task<User> GetUserByEmailAsync(string email)
		{
			// Truy vấn người dùng từ cơ sở dữ liệu theo tên người dùng
			var user = await _unitOfWork.Repository<User>()
				.FindAsync(u => u.Email == email);

			return user;
		}

        public async Task<UserDetailResponse> GetUserProfile(Guid id)
        {
            var user = await _unitOfWork.Repository<User>().GetByIdGuid(id);

            if (user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }                         

            var responseModel = new UserDetailResponse
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Dob = user.Dob,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Gender = user.Gender,
				RatingCount = user.Rating,
            };

            return responseModel;
        }
    }

}
