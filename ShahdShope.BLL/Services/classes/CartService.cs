using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.DTO.Requests;
using ShahdShope.DAL.DTO.Responses;
using ShahdShope.DAL.Models;
using ShahdShope.DAL.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.BLL.Services.classes
{
    public class CartService:ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public async Task<bool> AddToCartAsync(CartRequest request, string UserId)
        {
            var newCart = new Cart
            {
                ProductId = request.ProductId,
                UserId = UserId,
                Count = 1
            };
            return await _cartRepository.AddAsync(newCart) > 0;
        }

        public async Task<CartSummaryResponse> CartSummaryResponseAsync(string UserId)
        {
            var cartItems = await _cartRepository.GetUserCartAsync(UserId);
            var response = new CartSummaryResponse
            {
                Items = cartItems.Select(ci => new CartResponse
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Count = ci.Count,
                    Price = ci.Product.Price,

                }).ToList()

            };
            return response;
        }

        public async Task<bool> ClearCartAsync(string UserId)
        {
            return await _cartRepository.ClearCart(UserId);
        }
    }
}
