using AutoMapper;
using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using BurakBoz.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace BurakBoz.API.Controllers.Admin
{
    public class CategoriesController : AdminBaseController
    {

        private readonly IMapper mapper;
        private readonly IMainCategoryService mainCategoryService;
        private readonly ISubCategoryService subCategoryService;

        public CategoriesController(IMapper mapper, IMainCategoryService mainCategoryService, ISubCategoryService subCategoryService)
        {
            this.mapper = mapper;
            this.mainCategoryService = mainCategoryService;
            this.subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await mainCategoryService.GetAllAsync();
            return CreateActionResult(CustomResponseDto<IEnumerable<MainCategory>>.Success(200, categories));
        }

        [HttpGet("withsubcategories")]
        public async Task<IActionResult> GetWithSubCategories()
        {
            var categories = await mainCategoryService.GetWithSubCategories();
            return CreateActionResult(categories);
        }

        [HttpGet("withsubcategories/{id}")]
        public async Task<IActionResult> GetCategoryWithSubCategories(int id)
        {
            var categories = await mainCategoryService.GetWithSubCategories(id);
            return CreateActionResult(categories);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddMainCategory(MainCategory category)
        //{
        //    await mainCategoryService.AddAsync(category);
        //    return CreateActionResult(CustomResponseDto<MainCategory>.Success(200, category));
        //}

        [HttpPost]
        public async Task<IActionResult> AddMainCategoryWithImage([FromForm] MainCategoryWithFileDto category)
        {
            string pathC = Path.GetPathRoot(Environment.SystemDirectory);
            pathC += @"BurakBozWeb\CategoryImages";
            string path = "";
            Guid imageName = Guid.NewGuid();
            path = Path.Combine(pathC, imageName.ToString());
            path += Path.GetExtension(category.File.FileName);
            using (Stream stream = new FileStream(path, FileMode.Create))
            {
                category.File.CopyTo(stream);
            }
            category.Image = path;
            var newCategory = mapper.Map<MainCategory>(category);
            await mainCategoryService.AddAsync(newCategory);
            return CreateActionResult(CustomResponseDto<MainCategory>.Success(200, newCategory));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMainCategory([FromForm] MainCategoryWithFileDto category)
        {
            if (category.Id != null || category.Id!=0)
            {
                var selectedCategory = await mainCategoryService.GetByIdAsync((int) category.Id);
                selectedCategory.Name = category.Name;
                selectedCategory.Description = category.Description;
                selectedCategory.QueuePoint = (int) category.QueuePoint;
                selectedCategory.IsShow = category.IsShow;
                if (System.IO.File.Exists(selectedCategory.Image))
                {
                    System.IO.File.Delete(selectedCategory.Image);
                }


                string pathC = Path.GetPathRoot(Environment.SystemDirectory);
                pathC += @"BurakBozWeb\CategoryImages";
                string path = "";
                Guid imageName = Guid.NewGuid();
                path = Path.Combine(pathC, imageName.ToString());
                path += Path.GetExtension(category.File.FileName);
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    category.File.CopyTo(stream);
                }
                selectedCategory.Image = path;
                await mainCategoryService.UpdateAsync(selectedCategory);
                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));

            }
            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404,"Kategori bulunamadı"));

        }

        [HttpPut("visibility/{id}")]
        public async Task<IActionResult> MainCategoryChangeVisibility(int id)
        {
            return CreateActionResult(await mainCategoryService.ChangeVisibility(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMainCategory(int id)
        {
            //Alt nesneleri de siliyor.
            var category = await mainCategoryService.GetByIdAsync(id);
            if (category != null)
            {
                await mainCategoryService.RemoveAsync(category);
                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            }
            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Kategori bulunamadı."));

        }

        #region subCategory

        [HttpPost("addsubcategory")]
        public async Task<IActionResult> AddSubCategory(SubCategory category)
        {
            await subCategoryService.AddAsync(category);
            return CreateActionResult(CustomResponseDto<SubCategory>.Success(200, category));
        }

        [HttpPut("updatesubcategory")]
        public async Task<IActionResult> UpdateSubCategory(SubCategory updatedCategory)
        {
            await subCategoryService.UpdateAsync(updatedCategory);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("deletesubcategory/{id}")]
        public async Task<IActionResult> DeleteSubCategory(int id)
        {
            //Alt nesneleri de siliyor.
            var category = await subCategoryService.GetByIdAsync(id);
            if (category != null)
            {
                await subCategoryService.RemoveAsync(category);
                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            }
            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, "Kategori bulunamadı."));

        }

        [HttpPut("subcategoryvisibility/{id}")]
        public async Task<IActionResult> SubCategoryChangeVisibility(int id)
        {
            return CreateActionResult(await subCategoryService.ChangeVisibility(id));
        }

        [HttpGet("subcategories/{id}")]
        public async Task<IActionResult> GetSubCategories(int id)
        {
            return CreateActionResult(await subCategoryService.GetSubCategoriesByMainCategoryId(id));
        }


        #endregion
    }
}
