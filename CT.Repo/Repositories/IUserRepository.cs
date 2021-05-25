using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CT.Data.Models;

namespace CT.Repo.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(string id);
        Task Insert(User user);
        Task Update(User user);
        Task Delete(User user);
        Task SaveChanges();
    }
}
