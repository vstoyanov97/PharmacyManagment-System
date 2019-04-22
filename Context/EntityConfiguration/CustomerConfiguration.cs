using Microsoft.EntityFrameworkCore;
using StartUp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StartUp.Context.EntityConfiguration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FisrtName)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(c => c.LastName)
                .HasMaxLength(50).
                IsRequired(true);

            builder.Property(c => c.TelephoneNumber)
                .HasMaxLength(10)
                .IsRequired(true);

        }
    }
}
