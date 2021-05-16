using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CT.Data.Models.Mapping
{
    public class CollectionFolderMap
    {
        public CollectionFolderMap(EntityTypeBuilder<CollectionFolder> entityType)
        {
            entityType.HasKey(t => t.Id);
            entityType.Property(t => t.Description).HasMaxLength(1500);
            entityType.HasOne(t => t.User).WithMany(t => t.CollectionFolders).HasForeignKey(t => t.UserId).IsRequired();
        }
    }
}