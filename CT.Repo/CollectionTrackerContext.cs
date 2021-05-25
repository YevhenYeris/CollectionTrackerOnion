using System;
using CT.Data.Models;
using CT.Data.Models.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CT.Repo
{
    public class CollectionTrackerContext: IdentityDbContext<User>
    {
        /*public CollectionTrackerContext(DbContextOptions<CollectionTrackerContext> options)
            :base(options)
        {
        }*/

        public CollectionTrackerContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new AlloyMap(builder.Entity<Alloy>());
            new CollectibleItemMap(builder.Entity<CollectibleItem>());
            new CollectionFolderMap(builder.Entity<CollectionFolder>());
            new CollectionMap(builder.Entity<Collection>());
            new CurrencyMap(builder.Entity<Currency>());
            new ShapeMap(builder.Entity<Shape>());
            new SubjectMap(builder.Entity<Subject>());
            new CoinMap(builder.Entity<Coin>());
        }
    }
}
