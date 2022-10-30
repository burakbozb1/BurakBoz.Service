using AutoMapper;
using BurakBoz.Core.DTOs;
using BurakBoz.Core.Entities;
using BurakBoz.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurakBoz.API.Controllers.Admin
{
    public class StaticsController : AdminBaseController
    {
        private readonly IService<Static> staticService;
        private readonly IMapper mapper;

        public StaticsController(IService<Static> staticService, IMapper mapper)
        {
            this.staticService = staticService;
            this.mapper = mapper;
        }


        [HttpGet("hakkimda")]
        public async Task<IActionResult> GetHakkimizda()
        {
            var hakkimizda = await staticService.GetByIdAsync(2);
            return CreateActionResult(CustomResponseDto<Static>.Success(200, hakkimizda));
        }

        [HttpGet("cv")]
        public async Task<IActionResult> GetCv()
        {
            var hakkimizda = await staticService.GetByIdAsync(3);
            return CreateActionResult(CustomResponseDto<Static>.Success(200, hakkimizda));
        }

        [HttpGet("iletisim")]
        public async Task<IActionResult> GetIletsim()
        {
            var hakkimizda = await staticService.GetByIdAsync(4);
            return CreateActionResult(CustomResponseDto<Static>.Success(200, hakkimizda));
        }

        [HttpPut("updatehakkimda")]
        public async Task<IActionResult> UpdateHakkimizda(Static hakkimizda)
        {
            hakkimizda.UpdatedDate = DateTime.Now;
            await staticService.UpdateAsync(hakkimizda);
            return CreateActionResult(CustomResponseDto<Static>.Success(204));
        }

        [HttpPut("updatecv")]
        public async Task<IActionResult> UpdateCv(Static cv)
        {
            cv.UpdatedDate = DateTime.Now;
            await staticService.UpdateAsync(cv);
            return CreateActionResult(CustomResponseDto<Static>.Success(204));
        }

        [HttpPut("updateiletisim")]
        public async Task<IActionResult> UpdateIletisim(Static iletisim)
        {
            iletisim.UpdatedDate = DateTime.Now;
            await staticService.UpdateAsync(iletisim);
            return CreateActionResult(CustomResponseDto<Static>.Success(204));
        }
    }
}
