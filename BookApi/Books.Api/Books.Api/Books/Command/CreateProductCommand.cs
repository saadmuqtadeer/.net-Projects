using MediatR;

namespace Catalog.API.Products.Command
{
    public class CreateProductCommand : IRequest<CreateProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Category { get; set; } = new();
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }

    public class CreateProductResponse
    {
        public int Id { get; set; }
    }
}
