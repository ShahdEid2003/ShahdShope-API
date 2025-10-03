using ShahdShope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.BLL.Services.interfaces
{
    public interface IOrderService
    {
        Task<Order?> GetUserByOrder(int orderId);
        Task<Order?> AddAsync(Order order);
        Task<List<Order>> GetByStatus(StatusOrderEnum statusOrder);
        Task<List<Order>> GetOrderByUser(string userId);
        Task<bool> ChangeStatusAsync(string userId, StatusOrderEnum newStatus);
    }
}
