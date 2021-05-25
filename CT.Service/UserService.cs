using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using CT.Data.Models;
using CT.Repo.Repositories;

namespace CT.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteUser(string id)
        {
            var user = _repository.Get(id).Result;
            await _repository.Delete(user);
        }

        public async Task<User> GetUser(string id)
        {
            return await _repository.Get(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetAll();
        }

        public async Task InsertUser(User user)
        {
            await _repository.Insert(user);
        }

        public async Task UpdateUser(User user)
        {
            var u = await _repository.Get(user.Id);
            u.UserName = user.UserName;
            u.Email = user.Email;
            u.CountryId = user.CountryId;
            u.Description = user.Description;
            await _repository.Update(u);
        }
    }
}
