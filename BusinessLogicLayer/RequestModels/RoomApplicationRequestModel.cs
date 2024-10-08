using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.RequestModels
{
    public class RoomApplicationCreateRequestModel
    {
        //public string Field { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public string Dob { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public Guid RoomId { get; set; }

        public Guid UserId { get; set; }


    }

    public class RoomApplicationUpdateRequestModel
    {
        //public string Field { get; set; } = null!;
        public string FullName { get; set; } = null!;

        public string Dob { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public Guid RoomId { get; set; }

        public Guid UserId { get; set; }
    }
}
