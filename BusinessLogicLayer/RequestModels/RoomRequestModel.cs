using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.RequestModels
{
    public class RoomCreateRequestModel
    {
        //public string Field { get; set; } = null!;
        public string Name { get; set; } = null!;

        public int Rating { get; set; }

        public string Description { get; set; } = null!;

        public string Length { get; set; } = null!;

        public string Width { get; set; } = null!;

        public Guid HouseId { get; set; }

        public string Services { get; set; } = null!;
    }

    public class RoomUpdateRequestModel
    {
        //public string Field { get; set; } = null!;
        public string Name { get; set; } = null!;

        public int Rating { get; set; }

        public string Description { get; set; } = null!;

        public string Length { get; set; } = null!;

        public string Width { get; set; } = null!;

        public Guid HouseId { get; set; }

        public string Services { get; set; } = null!;
    }
}
