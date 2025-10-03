using ShahdShope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.DAL.Repositories.interfaces
{
    public interface IReviewRepository
    {
        Task<bool> HasUserReviewProduct(string userId, int productId);
        Task AddReviewAsync(Review request, string userId);
    }
}
