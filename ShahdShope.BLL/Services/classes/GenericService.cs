using Mapster;
using ShahdShope.BLL.Services.interfaces;
using ShahdShope.DAL.DTO.Responses;
using ShahdShope.DAL.Models;
using ShahdShope.DAL.Repositories.classes;
using ShahdShope.DAL.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahdShope.BLL.Services.classes
{
    public class GenericService<TRequest, TResponse, TEntity> : IGenericService<TRequest, TResponse, TEntity>
        where TEntity : BaseModel
    {
        private readonly IGenericRepositorry<TEntity> _repository;
        public GenericService(IGenericRepositorry<TEntity> genereicRepository)
        {
            this._repository = genereicRepository;
        }
        public int Create(TRequest request)
        {
            var entity = request.Adapt<TEntity>();
            return _repository.Add(entity);
        }

        public int Delete(int id)
        {
            var entity = _repository.GetById(id);
            if (entity is null)
            {
                return 0;

            }
            return _repository.Remove(entity);
        }

        public IEnumerable<TResponse> GetAll()
        {
            var entities = _repository.GetAll();
            return entities.Adapt<IEnumerable<TResponse>>();
        }

        public TResponse? GetById(int id)
        {
            var entity = _repository.GetById(id);
            return entity is null ? default : entity.Adapt<TResponse>();
        }

        public bool ToggleStatus(int id)
        {
            var entity = _repository.GetById(id);
            if  (entity is null)
            {
                return false;
            }
            entity.Status = entity.Status == Status.Active ? Status.Inactive : Status.Active;
            _repository.Update(entity);
            return true;
        }

        public int Update(int id, TRequest request)
        {
            var entity = _repository.GetById(id);
            if (entity is null)
            {
                return 0;
            }
            var updatedEntity =request.Adapt(entity);
            return _repository.Update(entity);
        }
    }
}
