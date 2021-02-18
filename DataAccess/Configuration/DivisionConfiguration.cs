using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class DivisionConfiguration : IEntityTypeConfiguration<Division>
    {
        public void Configure(EntityTypeBuilder<Division> entity)
        {
            entity.ToTable("Division");
            entity.HasIndex(e => e.Name).HasName("ui_division").IsUnique();
            entity.Property(e => e.Id).HasColumnName("DivisionID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false);
        }
    }
}
