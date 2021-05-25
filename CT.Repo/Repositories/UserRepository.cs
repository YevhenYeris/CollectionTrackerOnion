using System;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using CT.Data.Models;

namespace CT.Repo.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly CollectionTrackerContext _context;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
         
        public UserRepository(CollectionTrackerContext context, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            //return await System.Data.Entity.QueryableExtensions.ToListAsync(_userManager.Users);
            return await _userManager.Users.ToListAsync();
        }

        public async Task<User> Get(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task Insert(User user)
        {
            _ = user ?? throw new ArgumentNullException("user");
            await _userManager.CreateAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Update(User user)
        {
            _ = user ?? throw new ArgumentNullException("user");
            await _userManager.UpdateAsync(user);
        }

        public async Task Delete(User user)
        {
            _ = user ?? throw new ArgumentNullException("user");
            await _userManager.DeleteAsync(user);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
