using Core.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implements.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.OrderDate);
            builder.Property(t => t.Quantity);
            builder.Property(t => t.UnitPrice).HasPrecision(18,4);
            builder.Property(t => t.TotalPrice).HasPrecision(18,4);
            builder.HasOne(t => t.Category).WithMany(t => t.Orders).HasForeignKey(t => t.CategoryId);
            builder.HasOne(t => t.Product).WithMany(t => t.Orders).HasForeignKey(t => t.ProductId) ;
            builder.HasOne(t => t.Region).WithMany(t => t.Orders).HasForeignKey(t => t.RegionId);
            builder.HasOne(t => t.City).WithMany(t => t.Orders).HasForeignKey(t => t.CityId);

        }
    }
}
