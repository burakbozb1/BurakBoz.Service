using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.DTOs
{
    public class SubCategoryDto:CategoryDto
    {
        public int MainCategoryId { get; set; }
    }
}
