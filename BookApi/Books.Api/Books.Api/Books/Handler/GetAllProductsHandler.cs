using Catalog.API.Context;
using Catalog.API.Models;
using Catalog.API.Products.CreateProduct;
using Catalog.API.Products.Query;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Products.Handler
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Book>>
    {
        private readonly CatalogContext _context;
        public GetAllProductsHandler(CatalogContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = _context.Products.ToListAsync(cancellationToken);
            //var productsDto = products.Adapt<IEnumerable<ProducDto>>();
            return await products;
        }
    }
}
