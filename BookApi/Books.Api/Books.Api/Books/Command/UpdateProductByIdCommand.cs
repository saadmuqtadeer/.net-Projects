using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.Command
{
    public class UpdateProductByIdCommand: IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Category { get; set; } = new();
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        
    }
   
}
