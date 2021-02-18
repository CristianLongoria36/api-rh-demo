using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> entity)
        {
            entity.ToTable("Currency");
            entity.HasIndex(e => e.Name).HasName("ui_currency").IsUnique();
            entity.Property(e => e.Id).HasColumnName("CurrencyID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(3).IsUnicode(false);
            entity.HasData(
                new Currency { Id = 1, Name = "mxn" },
                new Currency { Id = 2, Name = "usd" },
                new Currency { Id = 3, Name = "eur" },
                new Currency { Id = 4, Name = "cad" }
            );
        }
    }
}
