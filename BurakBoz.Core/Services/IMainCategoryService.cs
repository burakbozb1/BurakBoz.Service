using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.Services
{
    public interface IMainCategoryService:IService<MainCategory>
    {
        Task<CustomResponseDto<List<MainCategory>>> GetWithSubCategories();
        Task<CustomResponseDto<MainCategory>> GetWithSubCategories(int id);
        Task<CustomResponseDto<NoContentDto>> ChangeVisibility(int id);
    }
}
