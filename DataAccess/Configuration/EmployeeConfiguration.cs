using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.ToTable("Employee");
            entity.HasIndex(e => e.Code).HasName("ui_code").IsUnique();
            entity.HasIndex(e => e.Fkuser).HasName("ui_fkuser").IsUnique();
            entity.Property(e => e.Id).HasColumnName("EmployeeID");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Code).IsRequired().HasMaxLength(150).IsUnicode(false);
            entity.Property(e => e.Fkcurrency).HasColumnName("FKCurrency");
            entity.Property(e => e.Fkdivision).HasColumnName("FKDivision");
            entity.Property(e => e.Fkposition).HasColumnName("FKPosition");
            entity.Property(e => e.Fkuser).HasColumnName("FKUser");
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");
            entity.HasOne(d => d.FkcurrencyNavigation)
                .WithMany(p => p.Employee)
                .HasForeignKey(d => d.Fkcurrency)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_currency");
            entity.HasOne(d => d.FkdivisionNavigation)
                .WithMany(p => p.Employee)
                .HasForeignKey(d => d.Fkdivision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_employee_division");
            entity.HasOne(d => d.FkpositionNavigation)
                .WithMany(p => p.Employee)
                .HasForeignKey(d => d.Fkposition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_position");
            entity.HasOne(d => d.FkuserNavigation)
                .WithOne(p => p.Employee)
                .HasForeignKey<Employee>(d => d.Fkuser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user");
        }
    }
}
