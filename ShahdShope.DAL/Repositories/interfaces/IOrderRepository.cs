using ShahdShope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.DAL.Repositories.interfaces
{
    public interface IOrderRepository
    {
        Task<Order?> GetUserByOrder(int orderId);
        Task<Order?> AddAsync(Order order);
    }
}
