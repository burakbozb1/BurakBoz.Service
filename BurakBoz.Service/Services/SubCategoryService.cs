using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using BurakBoz.Core.Repositories;
using BurakBoz.Core.Services;
using BurakBoz.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Service.Services
{
    public class SubCategoryService : Service<SubCategory>, ISubCategoryService
    {
        public SubCategoryService(IGenericRepository<SubCategory> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }

        public async Task<CustomResponseDto<NoContentDto>> ChangeVisibility(int id)
        {
            var subCategory = await repository.GetByIdAsync(id);
            subCategory.IsShow = !subCategory.IsShow;
            await unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<List<SubCategory>>> GetSubCategoriesByMainCategoryId(int id)
        {
            var subCategories = await repository.Where(x => x.MainCategoryId == id).ToListAsync();
            return CustomResponseDto<List<SubCategory>>.Success(200, subCategories);
        }
    }
}
