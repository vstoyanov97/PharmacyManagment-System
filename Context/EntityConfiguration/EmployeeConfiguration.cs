using Microsoft.EntityFrameworkCore;
using StartUp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StartUp.Context.EntityConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsRequired(true)
                ;
            builder.Property(e => e.LastName)
              .HasMaxLength(50)
              .IsRequired(true)
              ;

            builder.Property(e => e.Possition)
              .HasMaxLength(30)
              .IsRequired(true)
              ;



        }
    }
}
