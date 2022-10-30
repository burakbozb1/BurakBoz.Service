using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Status { get; set; }
        public DateTime UpdatedDate { get; set; }
        public SubCategory? SubCategory { get; set; }
    }
}
