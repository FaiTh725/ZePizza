using Profile.Domain.Models.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Models.Profile
{
    public class ViewProfile
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime? BirthDay {  get; set; }

        public List<ViewOrder> Orders { get; set; } = new List<ViewOrder>();
    }
}
