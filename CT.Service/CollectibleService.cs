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
    public class CollectibleService<T> : NamedService<T>, ICollectibleService<T> where T: CollectibleItem
    {
        public CollectibleService(IRepository<T> repository)
            :base(repository)
        {
        }

        public override async Task UpdateEntity(T entity)
        {
            await base.UpdateEntity(entity);
            var e = await _repository.Get(entity.Id);
            e.IsCommon = entity.IsCommon;
            e.AddedDate = entity.AddedDate;
            e.CountryId = entity.CountryId;
            e.CurrencyId = entity.CurrencyId;
            e.Description = entity.Description;
            e.Measuements = entity.Measuements;
            e.ModifiedDate = entity.ModifiedDate;
            e.Obverse = entity.Obverse;
            e.Reverse = entity.Reverse;
            e.SubjectId = entity.SubjectId;
            e.Year = entity.Year;
            await _repository.Update(e);
        }
    }
}
