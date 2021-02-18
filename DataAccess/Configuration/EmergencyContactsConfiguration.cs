using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class EmergencyContactsConfiguration : IEntityTypeConfiguration<EmergencyContacts>
    {
        public void Configure(EntityTypeBuilder<EmergencyContacts> entity)
        {
            entity.ToTable("EmergencyContacts");
            entity.Property(e => e.Id).HasColumnName("ContactsID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Fkemployee).HasColumnName("FKEmployee");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false);
            entity.HasOne(d => d.FkemployeeNavigation)
                .WithMany(p => p.EmergencyContacts)
                .HasForeignKey(d => d.Fkemployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employee_to_contacs");
        }
    }
}
