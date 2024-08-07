using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Models.Profile
{
    public class CreateProfile
    {
        public string Email { get; set; }

        public string UserName { get; set; } = string.Empty;
    }
}
