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
    internal class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SubCategoryId).IsRequired();
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.UpdatedDate).IsRequired();
            builder.HasOne(x => x.SubCategory).WithMany(x => x.Blogs).HasForeignKey(x => x.SubCategoryId);
        }
    }
}
