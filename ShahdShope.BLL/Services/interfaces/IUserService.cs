using ShahdShope.DAL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.BLL.Services.interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO> GetByIdAsync(string userId);
        Task<bool> BlockUserAsync(string id, int days);
        Task<bool> UnBlockUserAsync(string id);
        Task<bool> IsBlockUserAsync(string id);
        Task<bool> ChangeUserRoleAsync(string userId, string roleName);
    }
}
