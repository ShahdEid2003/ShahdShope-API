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
    public interface IAuthenticationService
    {
        Task<UserResponse> LoginAsync(LoginRequest request);
        Task<UserResponse> RegisterAsync(RegisterRequest request,HttpRequest Request);
        Task<string> ConfirmEmail(string token, string userId);
        Task<bool> ForgetPassword(ForgetPasswordRequest request);
        Task<bool> ResetPassword(ResetPasswordRequest request);
    }
}
