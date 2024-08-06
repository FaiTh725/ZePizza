using Profile.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Response
{
    public class Response
    {
        public string Description { get; set; } = string.Empty;

        public StatusCode StatusCode { get; set; }
    }
}
