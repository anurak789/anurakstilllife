using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ArtWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string FilePath { get; set; }
        public ArtType ArtType { get; set; }
        public Artist Artist { get; set; }
    }
}
