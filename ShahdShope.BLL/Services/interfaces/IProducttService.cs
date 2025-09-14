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
    public interface IProducttService : IGenericService<ProductRequest, ProductResponse, Product>
    {
        Task<int> CreateFile(ProductRequest request);
    }
}
