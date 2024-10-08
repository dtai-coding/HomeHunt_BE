using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ResponseModels
{
	public class UsersResponseModel
	{
		public Guid Id { get; set; }
		public string FullName { get; set; } = null!;
		public string Email { get; set; } = null!;
		public DateTime Dob { get; set; }
		public string Address { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string Gender { get; set; } = null!;
		public string RoleName { get; set; } = null!;

    }
    public class UserDetailResponse : UsersResponseModel
    {
        public double RatingCount { get; set; }
    }
}
