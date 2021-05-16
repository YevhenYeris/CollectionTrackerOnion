using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CT.Data.Models.Mapping
{
    public class CoinMap
    {
        public CoinMap(EntityTypeBuilder<Coin> entityType)
        {
            entityType.HasBaseType<CollectibleItem>();
            entityType.Property(t => t.Weight);
            entityType.HasOne(t => t.Shape).WithMany(t => t.Tokens).HasForeignKey(t => t.ShapeId).IsRequired();
            entityType.HasOne(t => t.Alloy).WithMany(t => t.Tokens).HasForeignKey(t => t.AlloyId).IsRequired();
        }
    }
}