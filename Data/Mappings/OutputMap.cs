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
    // Mapeado entidade de Saída.
    public class OutputMap : IEntityTypeConfiguration<Output>
    {
        public void Configure(EntityTypeBuilder<Output> builder)
        {
            builder.ToTable("Outputs");
            builder.HasKey(prop => prop.IdOutput);

            builder.Property(prop => prop.OutputStatus)
                .IsRequired()
                .HasColumnName("StatusOutput");
            builder.Property(prop => prop.Quantity)
               .IsRequired()
               .HasColumnName("Quantity"); 
        }
    }
}
