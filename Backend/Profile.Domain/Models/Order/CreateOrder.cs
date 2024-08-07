using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profile.Domain.Models.Order
{
    public class CreateOrder
    {
        public string EmailProfile {  get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty ;

        public string Currency { get; set; } = string.Empty;

        public long Amount { get; set; }

        public string Description { get; set; } = string.Empty;

        public string ReceiptEmail { get; set; } = string.Empty;
    }
}
