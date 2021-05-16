using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CT.Data.Models.Mapping
{
    public class SubjectMap
    {
        public SubjectMap(EntityTypeBuilder<Subject> entityType)
        {
            entityType.HasKey(t => t.Id);
            entityType.Property(t => t.Name).IsRequired().HasMaxLength(30);
        }
    }
}