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
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.CityName);
            builder.HasOne(t => t.Region).WithMany(t => t.Cities).HasForeignKey(t => t.RegionId);
        }
    }
}
