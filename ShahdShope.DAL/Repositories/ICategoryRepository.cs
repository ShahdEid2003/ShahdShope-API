using ShahdShope.DAL.Models;

namespace ShahdShope.DAL.Repositories
{
    public interface ICategoryRepository
    {
        int Add(Category category);
        IEnumerable<Category> GetAll(bool withTracking = false);
        Category? GetById(int id);
        int Remove(Category category);
        int Update(Category category);
    }
}