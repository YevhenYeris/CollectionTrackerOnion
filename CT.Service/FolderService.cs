using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using CT.Data.Models;
using CT.Repo.Repositories;

namespace CT.Services
{
    public class FolderService<T> : BaseService<T>, IFolderService<T> where T : CollectionFolder
    {
        public FolderService(IRepository<T> repository)
            : base(repository)
        {
        }

        public override async Task UpdateEntity(T entity)
        {
            var e = await _repository.Get(entity.Id);
            e.Description = entity.Description;
            e.UserId = entity.UserId;
            await _repository.Update(e);
        }
    }
}
