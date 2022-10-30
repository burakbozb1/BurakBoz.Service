using BurakBoz.Core.Entities;
using BurakBoz.Core.Enums;
using BurakBoz.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Repository.Repositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Blog>> GetBlogsByMainCategoryId(int id)
        {
            List<Blog> blogs = new List<Blog>();
            var subCategories = await context.SubCategories.Where(x => x.MainCategoryId == id).ToListAsync();
            foreach (var subCategory in subCategories)
            {
                var tmpBlogs = await context.Blogs.Where(x => x.SubCategoryId == subCategory.Id).ToListAsync();
                tmpBlogs.ForEach(x => {
                    x.SubCategory.Blogs.Clear();
                });
                blogs.AddRange(tmpBlogs);
            }
            return blogs;
        }

        public async Task<List<Blog>> GetBlogsByMainCategoryIdActives(int id)
        {
            List<Blog> blogs = new List<Blog>();
            var subCategories = await context.SubCategories.Where(x => x.MainCategoryId == id).ToListAsync();
            foreach (var subCategory in subCategories)
            {
                var tmpBlogs = await context.Blogs.Where(x => x.SubCategoryId == subCategory.Id && x.Status== (int)BlogStatus.Yayinda).ToListAsync();
                tmpBlogs.ForEach(x => {
                    x.SubCategory.Blogs.Clear();
                });
                blogs.AddRange(tmpBlogs);
            }
            return blogs;
        }

        public async Task<List<Blog>> GetBlogsBySubCategoryId(int id)
        {
            var blogs = await context.Blogs.Where(x => x.SubCategoryId == id).ToListAsync();
            return blogs;
        }

        public async Task<List<Blog>> SearchBlogBytitle(string text)
        {
            var blogs = await context.Blogs.Where(x => x.Title.Contains(text)).ToListAsync();
            return blogs;
        }
    }
}
