using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public double Amount { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public Profile Profile { get; set; }
    }
}
