using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.BLL.Services.interfaces
{
    public interface IFileService
    {
        Task<string> UplodeAsync(IFormFile file);
        Task<List<string>> UplodeManyAsync(List<IFormFile> files);
    }
}
