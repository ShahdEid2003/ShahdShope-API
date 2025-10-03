using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.DAL.Models
{
    public enum StatusOrderEnum
    {
        Pending = 1,
        Cancel = 2,
        approved = 3,
        Shipped = 4,
        Delivered = 5,

    }
    public enum StatusPaymentMethodEnum
    {
        Visa = 2,
        Cach = 1,

    }
    public class Order
    {
        public int Id { get; set; }
        public StatusOrderEnum Status { get; set; } = StatusOrderEnum.Pending;
      
        public DateTime OrderDate { get; set; }
   
        public DateTime ShippedDate { get; set; }

        public decimal TotalAmount { get; set; }

        public StatusPaymentMethodEnum PaymentMethod { get; set; }

      
        public string? PaymentId { get; set; }

        public string? CarrierName { get; set; }
        public string? TrackingNumber { get; set; }

  
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
