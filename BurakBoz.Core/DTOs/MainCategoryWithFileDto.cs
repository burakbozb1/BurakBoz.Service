using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.DTOs
{
    public class MainCategoryWithFileDto:CategoryDto
    {
        public string? Image { get; set; }
        public IFormFile? File { get; set; }
        public bool IsShow { get; set; }
    }
}
