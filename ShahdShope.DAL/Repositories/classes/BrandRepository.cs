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
    public class BrandRepository : GenereicRepository<Brand>,  IBrandRepository
    {
        public BrandRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
