using Microsoft.EntityFrameworkCore;
using StartUp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StartUp.Context.EntityConfiguration
{
    public class OrderMedicamentsConfiguration : IEntityTypeConfiguration<OrdersMedicaments>
    {
        public void Configure(EntityTypeBuilder<OrdersMedicaments> builder)
        {
            builder.HasKey(c => new
            {
                c.OrderId
                ,
                c.MedicamentId
            });

            builder.HasOne(b => b.OrderMedicament)
                .WithMany(c => c.OrderMedicaments)
                .HasForeignKey(b => b.MedicamentId);

            builder.HasOne(b => b.Order)
                .WithMany(c => c.OrderMedicaments)
                .HasForeignKey(b => b.OrderId);


                

        }
    }
}
