using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Models.Profile
{
    public class UpdateProfile
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public DateTime? BirthDay { get; set; }
    }
}
