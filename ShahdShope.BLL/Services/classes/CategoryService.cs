using Azure.Core;
using Azure;
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
    public class CategoryService : GenericService<CategoryRequest,CategoryResponses,Category>,ICategoryService
    {

        public CategoryService(ICategoryRepository Repository):base(Repository) 
        {
         
        }
   
    }
}
