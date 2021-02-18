using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("User");
            entity.HasIndex(e => e.Email).HasName("ui_email").IsUnique();
            entity.HasIndex(e => e.Token).HasName("ui_token").IsUnique();
            entity.Property(e => e.Id).HasColumnName("UserID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Fkrole).HasColumnName("FKRole");
            entity.Property(e => e.Password).IsRequired().HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.Token).IsRequired().HasMaxLength(32).IsUnicode(false);
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.IsLogin).HasDefaultValue(false);
            entity.HasOne(d => d.FkroleNavigation)
                .WithMany(p => p.User)
                .HasForeignKey(d => d.Fkrole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_role");
            //seed data
            entity.HasData(
                new User { Id = 1, Email = "admin@admin.com", Token = Guid.NewGuid().ToString("N"), Fkrole = 1, Password ="admin" }
            );
        }
    }
}
