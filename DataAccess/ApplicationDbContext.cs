using DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public virtual DbSet<BankData> BankData { get; set; }
        public virtual DbSet<Assistance> Assistance { get; set; }
        public virtual DbSet<Beneficiary> Beneficiary { get; set; }
        public virtual DbSet<TypeBeneficiary> TypeBeneficiary { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<EmergencyContacts> EmergencyContacts { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeData> EmployeeData { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Marital> Marital { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<RegistrationHistory> RegistrationHistory { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeDataConfiguration());
            modelBuilder.ApplyConfiguration(new MaritalConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new DivisionConfiguration());
            modelBuilder.ApplyConfiguration(new BankDataConfiguration());
            modelBuilder.ApplyConfiguration(new TypeBeneficiaryConfiguration());
            modelBuilder.ApplyConfiguration(new BeneficiaryConfiguration());
            modelBuilder.ApplyConfiguration(new RegistrationHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new EmergencyContactsConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
