using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.DAL.Models
{
    [PrimaryKey(nameof(ProductId), nameof(UserId))]
    public class Cart:BaseModel
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int Count { get; set; }
    }
}
