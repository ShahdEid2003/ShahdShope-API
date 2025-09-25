using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.DAL.DTO.Responses
{
    public class CheckoutResponse
    {
        public bool Success { get; set; }
        public required string Message { get; set; }
        public string? Url { get; set; }
        public string? PaymentId { get; set; }
    }
}
