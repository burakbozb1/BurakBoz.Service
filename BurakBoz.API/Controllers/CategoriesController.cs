using AutoMapper;
using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using BurakBoz.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BurakBoz.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly IMapper mapper;
        private readonly IService<MainCategory> mainCategoryService;
        private readonly IService<SubCategory> subCategoryService;

        public CategoriesController(IMapper mapper, IService<MainCategory> mainCategoryService, IService<SubCategory> subCategoryService)
        {
            this.mapper = mapper;
            this.mainCategoryService = mainCategoryService;
            this.subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMainCategories() {
            var mainCategories = await mainCategoryService.Where(x=> x.IsShow==true).ToListAsync();
            var categories = mapper.Map<List<MainCategoryDto>>(mainCategories);
            return CreateActionResult(CustomResponseDto<List<MainCategoryDto>>.Success(200, categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMainCategory(int id)
        {
            var mainCategory = await mainCategoryService.GetByIdAsync(id);
            var category = mapper.Map<MainCategoryDto>(mainCategory);
            return CreateActionResult(CustomResponseDto<MainCategoryDto>.Success(200, category));
        }

        [HttpGet("subcategories/{mainCategoryId}")]
        public async Task<IActionResult> GetSubCategories(int mainCategoryId)
        {
            var subCategories = await subCategoryService.Where(x => x.MainCategoryId == mainCategoryId && x.IsShow == true).ToListAsync();
            var categories = mapper.Map<List<SubCategoryDto>>(subCategories);
            return CreateActionResult(CustomResponseDto<List<SubCategoryDto>>.Success(200, categories));
        }

        [HttpGet("subcategory/{id}")]
        public async Task<IActionResult> GetSubCategory(int id)
        {
            var subCategory = await subCategoryService.GetByIdAsync(id);
            var category = mapper.Map<SubCategoryDto>(subCategory);
            return CreateActionResult(CustomResponseDto<SubCategoryDto>.Success(200, category));
        }
    }
}
