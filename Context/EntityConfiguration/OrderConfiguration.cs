using Microsoft.EntityFrameworkCore;
using StartUp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StartUp.Context.EntityConfiguration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Date).IsRequired(true);

            builder.HasOne(p => p.Employee)
                .WithMany(e => e.Orders)
                .HasForeignKey(p => p.EmployeeId);

            builder.HasOne(p => p.Customer)
                .WithMany(e => e.Orders)
                .HasForeignKey(p => p.CustomerId);

           

        }
    }
}
