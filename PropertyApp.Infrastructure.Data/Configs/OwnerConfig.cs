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
    class OwnerConfig : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owners");
            builder.HasKey(o => o.IdOwner);
            builder.Property(b => b.Birthday).IsRequired(false);
            builder.Property(b => b.Photo).IsRequired(false);
        }
    }
}
