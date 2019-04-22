using Microsoft.EntityFrameworkCore;
using StartUp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StartUp.Context.EntityConfiguration
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Name)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(m => m.Price).IsRequired(true);

            builder.Property(m => m.RequireRecipe).IsRequired(true);

            builder.HasOne(p => p.Pharmacist)
                .WithMany(e => e.SalesMedicaments)
                .HasForeignKey(p => p.EmployeeId);

            
        }
    }
}
