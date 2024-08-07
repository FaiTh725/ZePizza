using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Models.Order
{
    public class ViewOrder
    {
        public int Id { get; set; }

        public string Description { get; set; } = string.Empty;

        public double Amount { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
