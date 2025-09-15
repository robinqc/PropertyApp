using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyApp.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace PropertyApp.Infrastructure.Data.Configs
{
    class PropertyImageConfig : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToCollection("PropertyImages");
            builder.Property(image => image.IdPropertyImage).HasElementName("_id");
            builder.HasKey("IdPropertyImage");
        }
    }
}
