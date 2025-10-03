using Mapster;
using Microsoft.AspNetCore.Http;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.DTO.Requests;
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
    public class ProductService : GenericService<ProductRequest, ProductResponse, Product>, IProducttService
    {


        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;

        public ProductService(IProductRepository productRepository, IFileService fileService) : base(productRepository)
        {
            _productRepository = productRepository;
            _fileService = fileService;
        }

        public async Task<int> CreateProduct(ProductRequest request)
        {
            var entity = request.Adapt<Product>();
            entity.CreatedAt = DateTime.UtcNow;
            if (request.ImageMain != null)
            {
                var imagePath = await _fileService.UplodeAsync(request.ImageMain);
                entity.ImageMain = imagePath;
            }
          
        
            if (request.SubImage != null)
            {
                var subImagesPasths = await _fileService.UplodeManyAsync(request.SubImage);
                entity.SubImage = subImagesPasths.Select(img => new ProductImage { ImageName = img }).ToList();
            }
            return _productRepository.Add(entity);
        }
        public async Task<List<ProductResponse>> GetAllProduct(HttpRequest request, bool onlyActive = false, int pageSize = 1, int pageNumber = 1)
        {
            var products = _productRepository.GetAllproductWithImage();
            if (onlyActive)
            {
                products = products.Where(p => p.Status == Status.Active).ToList();
            }
            var pageProducts = products.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return pageProducts.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Quantity = p.Quantity,
                ImageMain = $"{request.Scheme}://{request.Host}/Image/{p.ImageMain}",
                SubImageUrls = p.SubImage.Select(img => $"{request.Scheme}://{request.Host}/Image/{img.ImageName}").ToList(),
                Reviews = p.Reviews.Select(p => new ReviewResponse
                {
                    Id = p.Id,
                    Comment = p.Comment,
                    Rate = p.Rate,
                    FullNmae = p.User.FullName,

                }).ToList(),
            }).ToList();
        }
    }
}
