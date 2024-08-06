using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Response
{
    public class DataResponse<T> : Response
    {
        public T Data { get; set; }
    }
}
