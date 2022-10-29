using BurakBoz.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Static> Statics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //assemblydeki IEntityTypeConfiguration interface'ini implement eden dosyaları bulur ve konfigurasyonları alır.
            base.OnModelCreating(modelBuilder);
        }
    }
}
