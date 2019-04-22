using Microsoft.EntityFrameworkCore;
using StartUp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StartUp.Context.EntityConfiguration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Speciality)
                .IsRequired()
                ;

            builder.Property(c => c.FirstName)
                .IsRequired(true)
                .HasMaxLength(50)
                ;

            builder.Property(c => c.LastName)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(c => c.Speciality)
                .IsRequired(true).
                HasMaxLength(50);

        }
    }
}
