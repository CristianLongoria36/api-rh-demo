using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> entity)
        {
            entity.ToTable("Position");
            entity.Property(e => e.Id).HasColumnName("PositionID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Fkdivision).HasColumnName("FKDivision");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false);
            entity.HasOne(d => d.FkdivisionNavigation)
                .WithMany(p => p.Position)
                .HasForeignKey(d => d.Fkdivision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_division");
        }
    }
}
