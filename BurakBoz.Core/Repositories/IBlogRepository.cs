using BurakBoz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.Repositories
{
    public interface IBlogRepository:IGenericRepository<Blog>
    {
        Task<List<Blog>> GetBlogsBySubCategoryId(int id);
        Task<List<Blog>> GetBlogsByMainCategoryId(int id);
        Task<List<Blog>> GetBlogsByMainCategoryIdActives(int id);
        Task<List<Blog>> SearchBlogBytitle(string text);
    }
}
