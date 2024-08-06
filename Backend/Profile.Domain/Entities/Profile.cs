using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Entities
{
    public class Profile
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime? BirthDay { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
