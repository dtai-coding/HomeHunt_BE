using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Feedback : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid HomeOwnerId { get; set; }

        public Guid RoommId { get; set; }

        public string Content { get; set; }

        public double Rating { get; set; }

        public DateTime Date { get; set; }
    }
}
