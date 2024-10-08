using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Contract: BaseEntity 
    {
        public Guid UserId { get; set; }

        public Guid HomeOwnerId { get; set; }

        public Guid RoommId { get; set; }

        public Decimal Price { get; set; }

        public DateTime Date { get; set; }


    }
}
