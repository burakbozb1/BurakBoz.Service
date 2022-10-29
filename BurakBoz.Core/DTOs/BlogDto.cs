using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.DTOs
{
    public class BlogDto
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
