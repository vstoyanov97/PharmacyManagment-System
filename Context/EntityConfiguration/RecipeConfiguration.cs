using Microsoft.EntityFrameworkCore;
using StartUp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StartUp.Context.EntityConfiguration
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Customer)
                .WithMany(s => s.Recipes)
                .HasForeignKey(c => c.CustomerId);

            builder.HasOne(c => c.Doctor)
                .WithMany(c => c.Recipes)
                .HasForeignKey(c => c.DoctorId);

            builder.HasOne(c => c.Medicament)
                .WithOne(c => c.Recipe)
                ;
        }
    }
}
