using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.Entities
{
    public class MainCategory:Category
    {
        public string Image { get; set; }
        public ICollection<SubCategory>? SubCategories { get; set; }
    }
}
