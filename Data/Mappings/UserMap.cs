using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
       

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.Name)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired() 
               .HasColumnName("Name") 
               .HasColumnType("varchar(100)"); 

            builder.Property(prop => prop.Email)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Email")
               .HasColumnType("varchar(50)");

            builder.Property(prop => prop.Password)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Password")
               .HasColumnType("varchar(100)");

            builder.Property(prop => prop.Occupation)
               .HasConversion(prop => prop.ToString(), prop => prop)
               .IsRequired()
               .HasColumnName("Occupation")
               .HasColumnType("varchar(100)");

            
        }
    }
}
