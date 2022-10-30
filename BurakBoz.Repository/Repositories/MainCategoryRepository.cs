using BurakBoz.Core.Entities;
using BurakBoz.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Repository.Repositories
{
    public class MainCategoryRepository : GenericRepository<MainCategory>, IMainCategoryRepository
    {
        public MainCategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<MainCategory>> GetWithSubCategories()
        {
            return await context.MainCategories.Include(x => x.SubCategories).ToListAsync();
        }

        public async Task<MainCategory> GetWithSubCategories(int id)
        {
            var category = await context.MainCategories.Include(x => x.SubCategories).SingleOrDefaultAsync(x => x.Id == id);
            return category;
        }
    }
}
