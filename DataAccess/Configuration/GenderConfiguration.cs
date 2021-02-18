using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> entity)
        {
            entity.ToTable("Gender");
            entity.HasIndex(e => e.Name).HasName("ui_gender").IsUnique();
            entity.Property(e => e.Id).HasColumnName("GenderID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            entity.HasData(
                new Gender { Id = 1, Name = "masculino" },
                new Gender { Id = 2, Name = "femenino" },
                new Gender { Id = 3, Name = "otro" }
            );
        }
    }
}
