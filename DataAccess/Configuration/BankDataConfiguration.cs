using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class BankDataConfiguration : IEntityTypeConfiguration<BankData>
    {
        public void Configure(EntityTypeBuilder<BankData> entity)
        {
            entity.ToTable("BankData");
            entity.HasIndex(e => e.AcountNumber).HasName("ui_acount").IsUnique();
            entity.HasIndex(e => e.Fkemployee).HasName("ui_fk_employee").IsUnique();
            entity.HasIndex(e => e.InterbankClabe).HasName("ui_interbank_clabe").IsUnique();
            entity.Property(e => e.Id).HasColumnName("BankDataID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.BankName).IsRequired().HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Fkemployee).HasColumnName("FKEmployee");
            entity.Property(e => e.TitularName).IsRequired().HasMaxLength(255).IsUnicode(false);
            entity.HasOne(d => d.FkemployeeNavigation)
                .WithOne(p => p.BankData)
                .HasForeignKey<BankData>(d => d.Fkemployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employee_to_bank");
        }
    }
}
