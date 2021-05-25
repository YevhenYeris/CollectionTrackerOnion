using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using CT.Data.Models;
using CT.Repo.Repositories;

namespace CT.Services
{
    public class CollectionService<T> : BaseService<T>, ICollectionService<T> where T : Collection
    {
        public CollectionService(IRepository<T> repository)
    : base(repository)
        {
        }

        public override async Task UpdateEntity(T entity)
        {
            await base.UpdateEntity(entity);
            var e = await _repository.Get(entity.Id);
            e.CollectibleItemId = entity.CollectibleItemId;
            e.CollectionFolderId = entity.CollectionFolderId;
            e.Description = entity.Description;
            await _repository.Update(e);
        }
    }
}
