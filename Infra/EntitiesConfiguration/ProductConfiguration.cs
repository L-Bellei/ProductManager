﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductManager.Domain.Entities;

namespace ProductManager.Infra.EntitiesConfiguration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .ToTable("Products");

        builder.HasKey(p => p.Id);
     
        builder
            .Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);
        
        builder
            .Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
        
        builder
            .Property(p => p.DefaultDiscount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder
            .Property(p => p.Quantity)
            .IsRequired();
    }
}
