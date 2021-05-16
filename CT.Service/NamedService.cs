using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using CT.Data.Models;
using CT.Repo.Repositories;

namespace CT.Services
{
    public class NamedService<T> : BaseService<T> where T: BaseNamedEntity
    {
        public NamedService(IRepository<T> repository)
            :base(repository)
        {
        }

        public override async Task UpdateEntity(T entity)
        {
            var e = await _repository.Get(entity.Id);
            e.Name = entity.Name;
            await _repository.Update(e);
        }
    }
}
