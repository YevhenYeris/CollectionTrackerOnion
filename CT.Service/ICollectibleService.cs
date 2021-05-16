using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using CT.Data.Models;

namespace CT.Services
{
    public interface ICollectibleService
    {
        Task<IEnumerable<CollectibleItem>> GetEntity();
        Task<CollectibleItem> GetEntity(int id);
        Task InsertEntity(CollectibleItem entity);
        Task UpdateEntity(CollectibleItem entity);
        Task DeleteEntity(int id);
    }
}
