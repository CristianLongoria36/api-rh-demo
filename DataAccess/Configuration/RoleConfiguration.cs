using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {

            entity.ToTable("Role");
            entity.HasIndex(e => e.Name).HasName("ui_role_name").IsUnique();
            entity.Property(e => e.Id).HasColumnName("RoleID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValue(true);
            //seed data
            entity.HasData(
                new Role { Id = 1, Name = "superadmin"},
                new Role { Id = 2, Name = "admin" },
                new Role { Id = 3, Name = "rh" },
                new Role { Id = 4, Name = "employee" }
           );
        }
    }
}
