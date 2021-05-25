using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using CT.Data.Models;
using CT.Repo.Repositories;

namespace CT.Services
{
    public class CoinService<T>: CollectibleService<T>, ICoinService<T> where T : Coin
    {
        public CoinService(IRepository<T> repository)
    : base(repository)
        {
        }

        public override async Task UpdateEntity(T entity)
        {
            await base.UpdateEntity(entity);
            var e = await _repository.Get(entity.Id);
            e.AlloyId = entity.AlloyId;
            e.ShapeId = entity.ShapeId;
            e.Weight = entity.Weight;
            await _repository.Update(e);
        }
    }
}
