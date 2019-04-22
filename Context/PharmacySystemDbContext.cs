using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using StartUp.Context.EntityConfiguration;
using StartUp.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace StartUp.Context
{
    public class PharmacySystemDbContext : DbContext
    {
        public PharmacySystemDbContext( DbContextOptions options) : base(options)
        {
        }

        public PharmacySystemDbContext()
        {
        }

    public    DbSet<Customer> Customers { get; set; }
     public   DbSet<CustomerMedicaments> CustomerMedicaments { get; set; }
      public  DbSet<Doctor> Doctors { get; set; }
      public  DbSet<Employee> Employees { get; set; }
     public   DbSet<Medicament> Medicaments { get; set; }
    public    DbSet<Order> Orders { get; set; }
     public   DbSet<OrdersMedicaments> OrdersMedicaments { get; set; }
     public   DbSet<Recipe> Recipies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerMedicamentsConfiguration());
            modelBuilder.ApplyConfiguration(new DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new MedicamentConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderMedicamentsConfiguration());
            modelBuilder.ApplyConfiguration(new RecipeConfiguration());

            

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.ConnectionString);

            }
        }
        public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(
                    entity,
                    validationContext,
                    validateAllProperties: true);
            }

            return base.SaveChanges();
        }


    }
}
