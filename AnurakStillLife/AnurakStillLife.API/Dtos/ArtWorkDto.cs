using Core;

namespace AnurakStillLife.API.Dtos
{
    public class ArtWorkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string FilePath { get; set; }
        public string ArtType { get; set; }
        public string Artist { get; set; }
    }
}
