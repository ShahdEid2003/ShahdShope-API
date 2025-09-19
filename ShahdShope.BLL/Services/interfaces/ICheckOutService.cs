using Microsoft.AspNetCore.Http;
using ShahdShope.DAL.DTO.Requests;
using ShahdShope.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.BLL.Services.interfaces
{
    public  interface ICheckOutService
    {
        Task<CheckoutResponse> ProccessPaymentAsync(CheckoutRequest request, string UserId, HttpRequest httpRequest);
        Task<bool> HendelPaymentSuccessAsync(int orderId);
    }
}
