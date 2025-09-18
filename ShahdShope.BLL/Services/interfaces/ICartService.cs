using ShahdShope.DAL.DTO.Requests;
using ShahdShope.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.BLL.Services.interfaces
{
    public interface ICartService
    {
        Task<bool> AddToCartAsync(CartRequest cartRequest, string userId);
        Task<CartSummaryResponse> CartSummaryResponseAsync(string userId);
        Task<bool> ClearCartAsync(string userId);
    }
}
