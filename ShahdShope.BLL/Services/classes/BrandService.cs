using Mapster;
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
    public class BrandService :GenericService<BrandRequest,BrandResponse, Brand>,IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IFileService _fileService;

        public BrandService(IBrandRepository brandRepository, IFileService fileService) : base(brandRepository)
        {
            _brandRepository = brandRepository;
            _fileService = fileService;
        }

        public async Task<int> CreateFile(BrandRequest request)
        {
            var entity = request.Adapt<Brand>();
            entity.CreatedAt = DateTime.UtcNow;
            if (entity.ImageMain != null)
            {
                var imagePath = await _fileService.UplodeAsync(request.ImageMain);
                entity.ImageMain = imagePath;
            }
            return _brandRepository.Add(entity);
        }

    }
}
