using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CT.Data.Models.Mapping
{
    public class CollectionMap
    {
        public CollectionMap(EntityTypeBuilder<Collection> entityType)
        {
            entityType.HasKey(t => t.Id);
            entityType.Property(t => t.Description).HasMaxLength(1500);
            entityType.HasOne(t => t.CollectionFolder).WithMany(t => t.Collections).HasForeignKey(t => t.CollectionFolderId).IsRequired().OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            entityType.HasOne(t => t.CollectibleItem).WithMany(t => t.Collections).HasForeignKey(t => t.CollectibleItemId).IsRequired();
        }
    }
}