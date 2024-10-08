using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.RequestModels
{
    public class RatingCreateRequestModel
    {
        //public string Field { get; set; } = null!;
        public Guid UserId { get; set; }

        public Guid RoomId { get; set; }

        public int Score { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; } = null!;
    }

    public class RatingUpdateRequestModel
    {
        //public string Field { get; set; } = null!;
        public Guid UserId { get; set; }

        public Guid RoomId { get; set; }

        public int Score { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; } = null!;
    }
}
