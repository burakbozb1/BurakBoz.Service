using AutoMapper;
using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using BurakBoz.Core.Repositories;
using BurakBoz.Core.Services;
using BurakBoz.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Service.Services
{
    public class MainCategoryService : Service<MainCategory>, IMainCategoryService
    {
        private readonly IMainCategoryRepository mainCategoryRepository;
        private readonly IMapper mapper;

        public MainCategoryService(IGenericRepository<MainCategory> repository, IUnitOfWork unitOfWork, IMapper mapper, IMainCategoryRepository mainCategoryRepository) : base(repository, unitOfWork)
        {
            this.mapper = mapper;
            this.mainCategoryRepository = mainCategoryRepository;
        }

        public async Task<CustomResponseDto<NoContentDto>> ChangeVisibility(int id)
        {
            var category = await mainCategoryRepository.GetByIdAsync(id);
            category.IsShow= !category.IsShow;
            await unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }

        public async Task<CustomResponseDto<List<MainCategory>>> GetWithSubCategories()
        {
            var categories = await mainCategoryRepository.GetWithSubCategories();
            return CustomResponseDto<List<MainCategory>>.Success(200, categories);
        }

        public async Task<CustomResponseDto<MainCategory>> GetWithSubCategories(int id)
        {
            var category = await mainCategoryRepository.GetWithSubCategories(id);
            return CustomResponseDto<MainCategory>.Success(200, category);
        }
    }
}
