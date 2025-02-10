using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Mapping
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
               .HasColumnType("integer")
               .ValueGeneratedOnAdd();

            builder.Property(s => s.TotalValue)
                .IsRequired()
                .HasColumnType("money");

            builder.Property(s => s.Subsidiary)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(s => s.Quantities)
                .IsRequired()
                .HasColumnType("integer");

            builder.Property(s => s.Discount)
                .IsRequired()
                .HasColumnType("float");

            builder.Property(s => s.WasCanceled)
                .IsRequired()
                .HasColumnType("bit")
                .HasDefaultValue(false);

            builder.Property(s => s.CreatedAt)
                .IsRequired();
        }
    }
}
