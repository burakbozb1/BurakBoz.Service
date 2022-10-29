using AutoMapper;
using BurakBoz.API.Enums;
using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using BurakBoz.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BurakBoz.API.Controllers
{
    public class BlogsController : CustomBaseController
    {
        private readonly IMapper mapper;
        private readonly IService<MainCategory> mainCategoryService;
        private readonly IService<SubCategory> subCategoryService;
        private readonly IService<Blog> blogService;

        public BlogsController(IMapper mapper, IService<MainCategory> mainCategoryService, IService<SubCategory> subCategoryService, IService<Blog> blogService)
        {
            this.mapper = mapper;
            this.mainCategoryService = mainCategoryService;
            this.subCategoryService = subCategoryService;
            this.blogService = blogService;
        }

        [HttpGet("all/{categoryId}")]
        public async Task<IActionResult> GetAllBlogs(int categoryId)
        {
            var subCategories = await subCategoryService.Where(x => x.MainCategoryId == categoryId && x.IsShow == true).ToListAsync();
            List<Blog> blogs = new List<Blog>();
            foreach (var subCategory in subCategories)
            {
                var foundedBlogs = await blogService.Where(x => x.SubCategoryId == subCategory.Id).ToListAsync();
                blogs.AddRange(foundedBlogs);
            }
            var blogsDto = mapper.Map<List<BlogDto>>(blogs);
            return CreateActionResult(CustomResponseDto<List<BlogDto>>.Success(200, blogsDto));
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetBlogs(int categoryId)
        {
            var blogs = await blogService.Where(x => x.SubCategoryId == categoryId && x.Status == (int)BlogStatus.Yayinda).OrderByDescending(x => x.UpdatedDate).ToListAsync();
            var blogsDto = mapper.Map<List<BlogDto>>(blogs);
            return CreateActionResult(CustomResponseDto<List<BlogDto>>.Success(200, blogsDto));
        }

        [HttpGet("/last5")]
        public async Task<IActionResult> Last5Blogs()
        {
            var blogs = await blogService.Where(x=> x.Status == (int)BlogStatus.Yayinda).OrderByDescending(x => x.UpdatedDate).Take(5).ToListAsync();
            var blogsDto = mapper.Map<List<BlogDto>>(blogs);
            return CreateActionResult(CustomResponseDto<List<BlogDto>>.Success(200, blogsDto));
        }

        [HttpGet("/last1")]
        public async Task<IActionResult> Last1Blog()
        {
            var blogs = await blogService.Where(x => x.Status == (int)BlogStatus.Yayinda).OrderByDescending(x => x.UpdatedDate).Take(1).ToListAsync();
            var blogDto = mapper.Map<BlogDto>(blogs[0]);
            return CreateActionResult(CustomResponseDto<BlogDto>.Success(200, blogDto));
        }

    }
}
