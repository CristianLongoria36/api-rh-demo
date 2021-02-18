using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class MaritalConfiguration : IEntityTypeConfiguration<Marital>
    {
        public void Configure(EntityTypeBuilder<Marital> entity)
        {
            entity.ToTable("MaritalStatus");
            entity.HasIndex(e => e.Name).HasName("ui_marital").IsUnique();
            entity.Property(e => e.Id).HasColumnName("MaritalID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            entity.HasData(
                new Marital { Id = 1, Name = "casado" },
                new Marital { Id = 2, Name = "casada" },
                new Marital { Id = 3, Name = "soltero" },
                new Marital { Id = 4, Name = "soltera" },
                new Marital { Id = 5, Name = "viudo" },
                new Marital { Id = 6, Name = "viuda" },
                new Marital { Id = 7, Name = "divorciado" },
                new Marital { Id = 8, Name = "divorciada" },
                new Marital { Id = 9, Name = "union libre" }
            );
        }
    }
}
