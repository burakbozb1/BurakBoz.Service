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
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.LinkType).IsRequired();
            builder.Property(x => x.Link).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.QueuePoint).IsRequired();
            builder.Property(x => x.IsShow).IsRequired();
        }
    }
}
