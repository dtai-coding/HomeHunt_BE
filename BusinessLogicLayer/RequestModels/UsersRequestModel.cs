using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.RequestModels
{
	public class UserCreateRequestModel
	{
		//public string Field { get; set; } = null!;
		public string FullName { get; set; } = null!;
		public string Password { get; set; } = null!;
		public string Email { get; set; } = null!;
		public DateTime Dob { get; set; }
		public string Address { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public Guid RoleId { get; set; }
        public string Gender { get; set; } = null!;
        public bool Status { get; set; }
    }

	public class UserUpdateRequestModel
	{
		//public string Field { get; set; } = null!;
		public string FullName { get; set; } = null!;
		//public string Password { get; set; } = null!;
		//public string Email { get; set; } = null!;
		public DateTime Dob { get; set; }
		public string Address { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public bool Status { get; set; }
        //public int RoleId { get; set; }
    }

}
