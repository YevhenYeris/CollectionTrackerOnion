using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using CT.Data.Models;
using CT.Repo.Repositories;

/*
 * TODO:
 * Implement (abstract) BaseService<BaseEntity> class implementing IBaseService<BaseEntity> interface. DONE
 * Implement NamedService<T> class inheriting from BaseService<T> where T : BaseNamedEntity.
 * Implement CollectibleItemService<T> class inheriting from NamedService<T> where T : CollectibleItem.
 * Implement other sevices left.
 */

namespace CT.Services
{
    class CollectibleService<T> : NamedService<T> where T: CollectibleItem
    {
        public CollectibleService(IRepository<T> repository)
            :base(repository)
        {
        }

        public Task DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CollectibleItem>> GetEntity()
        {
            throw new NotImplementedException();
        }

        public Task<CollectibleItem> GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertEntity(CollectibleItem entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEntity(CollectibleItem entity)
        {
            var e = await _repository.Get(entity.Id);
            throw new NotImplementedException();
        }
    }
}
