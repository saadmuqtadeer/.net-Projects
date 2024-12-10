using Catalog.API.Context;
using Catalog.API.Products.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Products.Handler
{
    public class UpdateProductRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Category { get; set; } = new();
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
    }

    public class UpdateProductHandler: IRequestHandler<UpdateProductByIdCommand, bool>
    {
        private readonly CatalogContext context;
        public UpdateProductHandler(CatalogContext context)
        {
           this.context = context;
        }

        public async Task<bool> Handle(UpdateProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (product != null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Category = request.Category;
                product.Price = request.Price;
                product.ImageFile = request.ImageFile;
                context.SaveChanges();
            }
            else return false;
            return true;
        }
    }
}
