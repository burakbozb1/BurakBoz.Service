using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.Services
{
    public interface ISubCategoryService:IService<SubCategory>
    {
        Task<CustomResponseDto<NoContentDto>> ChangeVisibility(int id);
        Task<CustomResponseDto<List<SubCategory>>> GetSubCategoriesByMainCategoryId(int id);
    }
}
