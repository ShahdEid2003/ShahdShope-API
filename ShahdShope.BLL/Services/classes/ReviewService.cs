using Mapster;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.DTO.Requests;
using ShahdShope.DAL.Models;
using ShahdShope.DAL.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.BLL.Services.classes
{
    public class ReviewService:IReviewService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IOrderRepository orderRepository, IReviewRepository reviewRepository)
        {
            _orderRepository = orderRepository;
            _reviewRepository = reviewRepository;
        }
        public async Task<bool> AddReviewAsync(ReviewRequest reviewRequest, string userId)
        {
            var hasOrder = await _orderRepository
                .UserHasApprovedOrderForProductAsync(userId, reviewRequest.ProductId);
            if (!hasOrder) return false;
            var areadyReviewed = await _reviewRepository.HasUserReviewProduct(userId, reviewRequest.ProductId);
            if (areadyReviewed) return false;

            var review = reviewRequest.Adapt<Review>();

            await _reviewRepository.AddReviewAsync(review, userId);
            return true;
        }
    }
}
