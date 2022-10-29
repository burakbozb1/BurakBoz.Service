using AutoMapper;
using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using BurakBoz.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BurakBoz.API.Controllers
{
    public class ValuesController : CustomBaseController
    {
        private readonly IMapper mapper;
        private readonly IService<SocialMedia> socialMediaService;

        public ValuesController(IMapper mapper, IService<SocialMedia> socialMediaService)
        {
            this.mapper = mapper;
            this.socialMediaService = socialMediaService;
        }

        public async Task<IActionResult> GetSocialMedias()
        {
            var socialMedias = await socialMediaService.Where(x => x.IsShow == true).ToListAsync();
            var social = mapper.Map<List<SocialMediaDto>>(socialMedias);
            return CreateActionResult(CustomResponseDto<List<SocialMediaDto>>.Success(200, social));
        }
    }
}
