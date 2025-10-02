using Mapster;
using Microsoft.AspNetCore.Identity;
using ShahdShope.BLL.Services.interfaces;
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
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IUserRepository userRepository, UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }


        public async Task<List<UserDTO>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var usersDto = new List<UserDTO>();
            foreach (var user in users)
            {
                var role = await _userManager.GetRolesAsync(user);
                usersDto.Add(new UserDTO
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    RoleName = role.FirstOrDefault()
                });
            }
            return usersDto;
        }



        public async Task<UserDTO> GetByIdAsync(string userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return user.Adapt<UserDTO>();
        }
        public async Task<bool> BlockUserAsync(string id, int days)
        {
            return await _userRepository.BlockUserAsync(id, days);
        }
        public async Task<bool> ChangeUserRoleAsync(string userId, string roleName)
        {
            return await _userRepository.ChangeUserRoleAsync(userId, roleName);
        }

        public async Task<bool> IsBlockUserAsync(string id)
        {
            return await _userRepository.IsBlockUserAsync(id);
        }

        public async Task<bool> UnBlockUserAsync(string id)
        {
            return await _userRepository.UnBlockUserAsync(id);
        }
    }
}
