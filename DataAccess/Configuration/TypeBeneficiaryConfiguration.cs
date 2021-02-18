using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class TypeBeneficiaryConfiguration : IEntityTypeConfiguration<TypeBeneficiary>
    {
        public void Configure(EntityTypeBuilder<TypeBeneficiary> entity)
        {

            entity.ToTable("TypeBenficiary");
            entity.HasIndex(e => e.Name).HasName("ui_type_beneficiary_name").IsUnique();
            entity.Property(e => e.Id).HasColumnName("TypeBeneficiaryID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50).IsUnicode(false);
            //seed data
            entity.HasData(
                new TypeBeneficiary { Id = 1, Name = "esposo" },
                new TypeBeneficiary { Id = 2, Name = "esposa" },
                new TypeBeneficiary { Id = 3, Name = "padre" },
                new TypeBeneficiary { Id = 4, Name = "madre" },
                new TypeBeneficiary { Id = 5, Name = "hijo" },
                new TypeBeneficiary { Id = 6, Name = "hija" },
                new TypeBeneficiary { Id = 3, Name = "hermano" },
                new TypeBeneficiary { Id = 3, Name = "hermana" }
           );
        }
    }
}
