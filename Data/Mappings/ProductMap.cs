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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(prop => prop.IdProduct);

            builder.Property(prop => prop.NameProduct)
               .HasConversion(prop => prop.ToUpper(), prop => prop)
               .IsRequired()
               .HasColumnName("NameProduct")
               .HasColumnType("varchar(100)");

        }
    }
}
