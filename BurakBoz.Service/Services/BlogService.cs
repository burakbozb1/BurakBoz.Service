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
    public class BlogService : Service<Blog>, IBlogService
    {
        private readonly IBlogRepository blogRepository;
        private readonly IMapper mapper;
        public BlogService(IGenericRepository<Blog> repository, IUnitOfWork unitOfWork, IBlogRepository blogRepository) : base(repository, unitOfWork)
        {
            this.blogRepository = blogRepository;
        }

        public async Task<CustomResponseDto<List<Blog>>> GetBlogsByMainCategoryId(int id)
        {
            var blogs = await blogRepository.GetBlogsByMainCategoryId(id);
            return CustomResponseDto<List<Blog>>.Success(200, blogs);
        }

        public async Task<CustomResponseDto<List<Blog>>> GetBlogsByMainCategoryIdActives(int id)
        {
            var blogs = await blogRepository.GetBlogsByMainCategoryIdActives(id);
            return CustomResponseDto<List<Blog>>.Success(200, blogs);
        }

        public async Task<CustomResponseDto<List<Blog>>> GetBlogsBySubCategoryId(int id)
        {
            var blogs = await blogRepository.GetBlogsBySubCategoryId(id);
            return CustomResponseDto<List<Blog>>.Success(200, blogs);
        }

        public async Task<CustomResponseDto<List<Blog>>> SearchBlogBytitle(string text)
        {
            var blogs = await blogRepository.SearchBlogBytitle(text);
            return CustomResponseDto<List<Blog>>.Success(200, blogs);
        }
    }
}
