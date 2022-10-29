using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.Entities
{
    public abstract class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QueuePoint { get; set; }
        public bool IsShow { get; set; }
    }
}
