using Microsoft.EntityFrameworkCore;
using StartUp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StartUp.Context.EntityConfiguration
{
    class CustomerMedicamentsConfiguration : IEntityTypeConfiguration<CustomerMedicaments>
    {
        public void Configure(EntityTypeBuilder<CustomerMedicaments> builder)
        {
            builder.HasKey(c => new
            {
                c.CustomerId,
                c.MedicamentId
            });

            builder.HasOne(c => c.Customer)
                .WithMany(c => c.CustomerMedicaments)
                .HasForeignKey(c => c.CustomerId);

            builder.HasOne(c => c.CustomerMedicament)
                .WithMany(c => c.CustomerMedicaments)
                .HasForeignKey(c => c.MedicamentId);
        }
    }
}
