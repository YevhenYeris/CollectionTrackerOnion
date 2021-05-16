using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CT.Data.Models.Mapping
{
    public class AlloyMap
    {
        public AlloyMap(EntityTypeBuilder<Alloy> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired().HasMaxLength(30);
        }
    }
}
