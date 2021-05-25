using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using CT.Data.Models;

namespace CT.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(string id);
        Task InsertUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(string id);
    }
}
