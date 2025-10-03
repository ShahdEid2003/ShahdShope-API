using ShahdShope.DAL.DTO.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.BLL.Services.interfaces
{
    public interface IReviewService
    {
        Task<bool> AddReviewAsync(ReviewRequest reviewRequest, string userId);
    }
}
