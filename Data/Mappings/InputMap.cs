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
    public class InputMap : IEntityTypeConfiguration<Input>
    {
        public void Configure(EntityTypeBuilder<Input> builder)
        {
            builder.ToTable("Inputs");
            builder.HasKey(prop => prop.IdInput);

            builder.Property(prop => prop.Quantity)
                .IsRequired()
                .HasColumnName("Quantity");
        }
    }
}
