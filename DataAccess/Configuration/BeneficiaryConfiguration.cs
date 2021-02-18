using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class BeneficiaryConfiguration : IEntityTypeConfiguration<Beneficiary>
    {
        public void Configure(EntityTypeBuilder<Beneficiary> entity)
        {
            entity.ToTable("Beneficiary");
            entity.Property(e => e.Id).HasColumnName("BeneficiaryID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Fkemployee).HasColumnName("FKEmployee");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Fktype).HasColumnName("FKTypeBeneciary");
            entity.HasOne(d => d.FkbeneficiaryNavigation)
                .WithMany(p => p.Beneficiary)
                .HasForeignKey(d => d.Fktype)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_type_beneciary");
            entity.HasOne(d => d.FkemployeeNavigation)
                .WithMany(p => p.Beneficiary)
                .HasForeignKey(d => d.Fkemployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employee");
        }
    }
}
