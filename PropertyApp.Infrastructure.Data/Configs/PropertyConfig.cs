using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PropertyApp.Infrastructure.Data.Configs
{
    class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Properties");
            builder.HasKey(p => p.IdProperty);
            builder.HasOne<Owner>()
                   .WithMany()
                   .HasForeignKey(p => p.IdOwner)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
