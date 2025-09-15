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
    class PropertyConfig : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToCollection("Properties");
            builder.Property(property => property.IdProperty).HasElementName("_id");
            builder.HasKey("IdProperty");

        }
    }
}
