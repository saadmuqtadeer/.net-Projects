using Catalog.API.Context;
using Catalog.API.Models;
using Catalog.API.Products.Query;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Catalog.API.Products.Handler
{
    public class GetProductByIdHandler: IRequestHandler<GetProductByIdQuery, Book>
    {
        private readonly CatalogContext _context;

        public GetProductByIdHandler(CatalogContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken) ;
            return product;
        }
    }
}
