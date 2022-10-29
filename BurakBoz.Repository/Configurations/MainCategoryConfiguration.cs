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
    public class MainCategoryConfiguration : IEntityTypeConfiguration<MainCategory>
    {
        public void Configure(EntityTypeBuilder<MainCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.QueuePoint).IsRequired();
            builder.Property(x => x.IsShow).IsRequired();
        }
    }
}
