using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using CT.Data.Models;
using CT.Repo.Repositories;

namespace CT.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetEntity()
        {
            return await _repository.GetAll();
        }

        public virtual async Task<T> GetEntity(int id)
        {
            return await _repository.Get(id);
        }

        public virtual async Task InsertEntity(T entity)
        {
            await _repository.Insert(entity);
        }

        public virtual async Task UpdateEntity(T entity)
        {
            var e = await _repository.Get(entity.Id);
            await _repository.Update(e);
        }

        public virtual async Task DeleteEntity(int id)
        {
            var e = await _repository.Get(id);
            await _repository.Delete(e);
        }

    }
}
