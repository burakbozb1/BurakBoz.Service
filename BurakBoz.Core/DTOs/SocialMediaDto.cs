using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurakBoz.Core.DTOs
{
    public class SocialMediaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int LinkType { get; set; }
        public string Image { get; set; }
        public int QueuePoint { get; set; }
    }
}
