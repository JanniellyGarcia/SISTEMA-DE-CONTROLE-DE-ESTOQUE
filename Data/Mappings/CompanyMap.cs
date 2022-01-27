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
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");

            builder.HasKey(prop => prop.IdCompany);

            builder.Property(prop => prop.NameCompany)
               .HasConversion(prop => prop.ToString().ToUpper(), prop => prop)
               .IsRequired()
               .HasColumnName("NameCompany")
               .HasColumnType("varchar(100)");
        }
    }
}
