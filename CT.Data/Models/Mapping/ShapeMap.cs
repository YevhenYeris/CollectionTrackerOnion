using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CT.Data.Models.Mapping
{
    public class ShapeMap
    {
        public ShapeMap(EntityTypeBuilder<Shape> entityType)
        {
            entityType.HasKey(t => t.Id);
            entityType.Property(t => t.Name).IsRequired().HasMaxLength(30);
        }
    }
}