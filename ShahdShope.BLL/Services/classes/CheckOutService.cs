using Microsoft.AspNetCore.Http;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.DTO.Requests;
using ShahdShope.DAL.DTO.Responses;
using ShahdShope.DAL.Models;
using ShahdShope.DAL.Repositories.interfaces;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.BLL.Services.classes
{
    public class CheckOutService : ICheckOutService
    {
        public ICartRepository _cartRepository { get; }

        public CheckOutService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public Task<CheckoutResponse> ProccessPaymentAsync(CheckoutRequest request, string UserId, HttpRequest httpRequest)
        {
            throw new NotImplementedException();
        }
        public Task<bool> HendelPaymentSuccessAsync(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
