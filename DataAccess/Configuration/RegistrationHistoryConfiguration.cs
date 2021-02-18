using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class RegistrationHistoryConfiguration : IEntityTypeConfiguration<RegistrationHistory>
    {
        public void Configure(EntityTypeBuilder<RegistrationHistory> entity)
        {
            entity.ToTable("RegistrationHistory");
            entity.Property(e => e.Id).HasColumnName("RegistrationID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DateFinish).HasColumnType("date").HasDefaultValue(null);
            entity.Property(e => e.DateStarted).HasColumnType("date");
            entity.Property(e => e.Fkemployee).HasColumnName("FKEmployee");
            entity.HasOne(d => d.FkemployeeNavigation)
                .WithMany(p => p.RegistrationHistory)
                .HasForeignKey(d => d.Fkemployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employee_to_registration");
        }
    }
}
