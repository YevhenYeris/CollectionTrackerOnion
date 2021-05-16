using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CT.Data.Models.Mapping
{
    public class CollectibleItemMap
    {
        public CollectibleItemMap(EntityTypeBuilder<CollectibleItem> entityType)
        {
            entityType.HasKey(t => t.Id);
            entityType.Property(t => t.IsCommon).IsRequired();
            entityType.Property("Discriminator").IsRequired().HasMaxLength(200);
            entityType.Property(t => t.Measuements);
            entityType.Property(t => t.ModifiedDate).IsRequired();
            entityType.Property(t => t.Name).IsRequired().HasMaxLength(200);
            entityType.Property(t => t.Obverse);
            entityType.Property(t => t.Reverse);
            entityType.Property(t => t.AddedDate).IsRequired();
            entityType.Property(t => t.Description).IsRequired().HasMaxLength(1500);
            entityType.Property(t => t.Year);
            entityType.HasOne(t => t.Subject).WithMany(t => t.CollectibleItems).HasForeignKey(t => t.SubjectId).IsRequired();
            entityType.HasOne(t => t.Country).WithMany(t => t.CollectibleItems).HasForeignKey(t => t.CountryId).IsRequired();
            entityType.HasOne(t => t.Currency).WithMany(t => t.CollectibleItems).HasForeignKey(t => t.CurrencyId).IsRequired();
        }
    }
}
