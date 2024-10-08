using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.RequestModels
{
    public class PostCreateRequestModel
    {
        //public string Field { get; set; } = null!;
        public Guid RoomId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }

    public class PostUpdateRequestModel
    {
        //public string Field { get; set; } = null!;
        public Guid RoomId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
