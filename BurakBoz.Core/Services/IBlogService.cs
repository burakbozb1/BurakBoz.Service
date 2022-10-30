using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.Services
{
    public interface IBlogService:IService<Blog>
    {
        Task<CustomResponseDto<List<Blog>>> GetBlogsBySubCategoryId(int id);
        Task<CustomResponseDto<List<Blog>>> GetBlogsByMainCategoryId(int id);
        Task<CustomResponseDto<List<Blog>>> GetBlogsByMainCategoryIdActives(int id);
        Task<CustomResponseDto<List<Blog>>> SearchBlogBytitle(string text);
    }
}
