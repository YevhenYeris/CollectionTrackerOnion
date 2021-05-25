using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CT.Data.Models;

namespace CT.Repo.Repositories
{
    //to use include. servive (class + interface) to be implemented
    public class CountryRepo<T> : Repository<T> where T: Country
    {
        public CountryRepo(CollectionTrackerContext context)
            :base(context)
        {
            _entities = _context.Set<T>();
        }

        public override async Task<T> Get(int id)
        {
            return await _entities.Include(e => e.CollectibleItems).SingleOrDefaultAsync(e => e.Id == id);
        }
    }
}
