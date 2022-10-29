using BurakBoz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Repository.Configurations
{
    public class StaticConfiguration : IEntityTypeConfiguration<Static>
    {
        public void Configure(EntityTypeBuilder<Static> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();
        }
    }
}
