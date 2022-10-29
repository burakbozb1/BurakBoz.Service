using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.Entities
{
    public class SubCategory:Category
    {
        public int MainCategoryId { get; set; }
        public MainCategory MainCategory { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
