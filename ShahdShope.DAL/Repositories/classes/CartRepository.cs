using Microsoft.EntityFrameworkCore;
using ShahdShope.DAL.Data;
using ShahdShope.DAL.Models;
using ShahdShope.DAL.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.DAL.Repositories.classes
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;

        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> ClearCart(string UserId)
        {
            var items = _context.Carts.Where(c => c.UserId == UserId).ToList(); 
            _context.Carts.RemoveRange(items);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cart>> GetUserCartAsync(string UserId)
        {
            return await _context.Carts.Include(c => c.Product).Where(c => c.UserId == UserId).ToListAsync();
        }
    }
}
