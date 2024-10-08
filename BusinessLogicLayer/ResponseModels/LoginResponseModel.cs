using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.ResponseModels
{
	public class LoginResponseModel
	{
		public string Token { get; set; }

		public UsersResponseModel User { get; set; }
    }
}
