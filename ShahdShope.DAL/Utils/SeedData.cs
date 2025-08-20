using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShahdShope.DAL.Data;
using ShahdShope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.DAL.Utils
{
    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedData(ApplicationDbContext context, RoleManager<IdentityRole> roleManager ,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task DataSeedingAsync()
        {
            if ((await _context.Database.GetPendingMigrationsAsync()).Any())
            {
                await _context.Database.MigrateAsync();
            }

            if (!await _context.Categories.AnyAsync())
            {
                 await _context.Categories.AddRangeAsync(
                    new Category { Name = "Clothes" },
                    new Category { Name = "Mobiles" }
                );
             
            }

            if (!await _context.Brands.AnyAsync())
            {
                await _context.Brands.AddRangeAsync(
                    new Brand { Name = "Samsung" },
                    new Brand { Name = "Apple" },
                    new Brand { Name = "Nike" }
                );
             
            }
            await _context.SaveChangesAsync();
        }

        public async Task IdentityDataSeedingAsync()
        {
            if(!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }
            if (!await _userManager.Users.AnyAsync())
            {
                var user1 = new ApplicationUser()
                {
                    Email = "shahd@gmail.com",
                    FullName = "Shahd Eid",
                    PhoneNumber = "0599372949",
                    UserName = "shahd"
                };
                var user2 = new ApplicationUser()
                {
                    Email = "Taher@gmail.com",
                    FullName = "Taher Eid",
                    PhoneNumber = "0539372949",
                    UserName = "Taher"
                };
                var user3 = new ApplicationUser()
                {
                    Email = "Lama@gmail.com",
                    FullName = "Lama Eid",
                    PhoneNumber = "0595372949",
                    UserName = "Lama"
                };
                await _userManager.CreateAsync(user1,"Pass@1212");
                await _userManager.CreateAsync(user2, "Pass@1212");
                await _userManager.CreateAsync(user3, "Pass@1212");

                await _userManager.AddToRoleAsync(user1,"Admin");
                await _userManager.AddToRoleAsync(user1, "SuperAdmin");
                await _userManager.AddToRoleAsync(user1, "Customer");
            }
            await _context.SaveChangesAsync();
        }
    }
}
