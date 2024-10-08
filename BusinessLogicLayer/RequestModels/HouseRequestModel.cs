using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.RequestModels
{
    public class HouseCreateRequestModel
    {
        //public string Field { get; set; } = null!;
        public string Address { get; set; } = null!;

        public string Ward { get; set; } = null!;

        public string District { get; set; } = null!;

        public string City { get; set; } = null!;
    }

    public class HouseUpdateRequestModel
    {
        //public string Field { get; set; } = null!;
        public string Address { get; set; } = null!;

        public string Ward { get; set; } = null!;

        public string District { get; set; } = null!;

        public string City { get; set; } = null!;
    }
}
