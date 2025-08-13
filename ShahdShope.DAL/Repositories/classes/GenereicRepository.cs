using Microsoft.EntityFrameworkCore;
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
    public class GenereicRepository<T> : IGenericRepositorry<T> where T : BaseModel
    {
        private readonly ApplicationDbContext context;

        public GenereicRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int Add(T entity)
        {
            context.Set<T>().Add(entity);
            return context.SaveChanges();
        }

        public IEnumerable<T> GetAll(bool withTracking = false)
        {
            if (withTracking)
                return context.Set<T>().ToList();

            return context.Set<T>().AsNoTracking().ToList();
        }

        public T? GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
  

        public int Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            return context.SaveChanges();
        }

        public int Update(T entity)
        {
            context.Set<T>().Update(entity);
            return context.SaveChanges();
        }
    }
}
