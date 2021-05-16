using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CT.Data.Models;

namespace CT.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetEntity();
        Task<T> GetEntity(int id);
        Task InsertEntity(T entity);
        Task UpdateEntity(T entity);
        Task DeleteEntity(int id);
    }
}
