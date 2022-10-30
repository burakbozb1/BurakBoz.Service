using AutoMapper;
using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using BurakBoz.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BurakBoz.API.Controllers.Admin
{
    public class BlogsController : AdminBaseController
    {
        //private readonly IService<Blog> blogService;
        private readonly IBlogService blogService;
        private readonly IMapper mapper;

        public BlogsController(IMapper mapper, IBlogService blogService)
        {
            this.mapper = mapper;
            this.blogService = blogService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBlog(Blog blog)
        { 
            blog.UpdatedDate = DateTime.Now;
            await blogService.AddAsync(blog);
            return CreateActionResult(CustomResponseDto<Blog>.Success(200, blog));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBlog(Blog blog)
        {
            blog.UpdatedDate = DateTime.Now;
            await blogService.UpdateAsync(blog);
            return CreateActionResult(CustomResponseDto<Blog>.Success(204));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlog(int id)
        { 
            var blog = await blogService.GetByIdAsync(id);
            return CreateActionResult(CustomResponseDto<Blog>.Success(200, blog));
        }

        [HttpGet("bysubcategory/{id}")]
        public async Task<IActionResult> GetBlogsBySubCategory(int id)
        {
            return CreateActionResult(await blogService.GetBlogsBySubCategoryId(id));
        }

        [HttpGet("bymaincategory/{id}")]
        public async Task<IActionResult> GetBlogsByMainCategory(int id)
        {
            return CreateActionResult(await blogService.GetBlogsByMainCategoryId(id));
        }

        [HttpGet("searchblog/{text}")]
        public async Task<IActionResult> SearchBlog(string text)
        {
            return CreateActionResult(await blogService.SearchBlogBytitle(text));
        }


    }
}
