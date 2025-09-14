using ShahdShope.DAL.DTO.Requests;
using ShahdShope.DAL.DTO.Responses;
using ShahdShope.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.BLL.Services.interfaces
{
    public interface IBrandService : IGenericService<BrandRequest, BrandResponse, Brand>
    {
        Task<int> CreateFile(BrandRequest request);
    }
}

