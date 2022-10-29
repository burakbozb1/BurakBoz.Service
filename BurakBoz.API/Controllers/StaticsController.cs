using AutoMapper;
using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using BurakBoz.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurakBoz.API.Controllers
{
    public class StaticsController : CustomBaseController
    {

        private readonly IMapper mapper;
        private readonly IService<Static> staticService;

        public StaticsController(IMapper mapper, IService<Static> staticService)
        {
            this.mapper = mapper;
            this.staticService = staticService;
        }

        [HttpGet("hakkimda")]
        public async Task<IActionResult> GetHakkimda()
        {
            var hakkimdaText = await staticService.GetByIdAsync(2);
            var hakkimda = mapper.Map<StaticDto>(hakkimdaText);
            return CreateActionResult(CustomResponseDto<StaticDto>.Success(200, hakkimda));
        }

        [HttpGet("cv")]
        public async Task<IActionResult> GetCV()
        {
            var cvText = await staticService.GetByIdAsync(3);
            var cv = mapper.Map<StaticDto>(cvText);
            return CreateActionResult(CustomResponseDto<StaticDto>.Success(200, cv));
        }

        [HttpGet("iletisim")]
        public async Task<IActionResult> GetIletisim()
        {
            var contactText = await staticService.GetByIdAsync(4);
            var contact = mapper.Map<StaticDto>(contactText);
            return CreateActionResult(CustomResponseDto<StaticDto>.Success(200, contact));
        }
    }
}
