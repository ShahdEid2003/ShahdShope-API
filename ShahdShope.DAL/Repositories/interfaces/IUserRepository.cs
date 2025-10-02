using ShahdShope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.DAL.Repositories.interfaces
{
    public interface IUserRepository
    {
        Task<List<ApplicationUser>> GetAllAsync();
        Task<ApplicationUser> GetByIdAsync(string id);
        Task<bool> BlockUserAsync(string id, int days);
        public Task<bool> UnBlockUserAsync(string id);
        public Task<bool> IsBlockUserAsync(string id);
        Task<bool> ChangeUserRoleAsync(string userId, string roleName);

    }
}
