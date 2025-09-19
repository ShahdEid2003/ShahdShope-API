using ShahdShope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.DAL.DTO.Requests
{
    public class CheckoutRequest
    {
        public StatusPaymentMethodEnum PaymentMethod { get; set; }
    }
}
