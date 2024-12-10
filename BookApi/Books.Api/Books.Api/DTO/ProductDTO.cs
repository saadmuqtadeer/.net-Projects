namespace Catalog.API.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Category { get; set; } = new();
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }
}
