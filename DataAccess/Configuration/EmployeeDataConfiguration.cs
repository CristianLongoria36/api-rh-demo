using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class EmployeeDataConfiguration : IEntityTypeConfiguration<EmployeeData>
    {
        public void Configure(EntityTypeBuilder<EmployeeData> entity)
        {
            entity.ToTable("EmployeeData");
            entity.HasIndex(e => e.Fkemployee).HasName("ui_fk_employee").IsUnique();
            entity.Property(e => e.Id).HasColumnName("EmployeeDataID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Address).IsRequired().HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.DateBirth).HasColumnType("date");
            entity.Property(e => e.FirtsSurname).IsRequired().HasColumnName("Firts_Surname").HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Fkemployee).HasColumnName("FKEmployee");
            entity.Property(e => e.Fkgender).HasColumnName("FKGender");
            entity.Property(e => e.Fkmarital).HasColumnName("FKMarital");
            entity.Property(e => e.Image).IsRequired().HasMaxLength(255).IsUnicode(false).HasDefaultValue("default_user.jpg");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.SecondSurname).IsRequired().HasColumnName("Second_Surname").HasMaxLength(255).IsUnicode(false);
            entity.HasOne(d => d.FkemployeeNavigation)
                .WithOne(p => p.EmployeeData)
                .HasForeignKey<EmployeeData>(d => d.Fkemployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employee_to_data");
            entity.HasOne(d => d.FkgenderNavigation)
                .WithMany(p => p.EmployeeData)
                .HasForeignKey(d => d.Fkgender)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_gender");
            entity.HasOne(d => d.FkmaritalNavigation)
                .WithMany(p => p.EmployeeData)
                .HasForeignKey(d => d.Fkmarital)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_marital");
        }
    }
}
