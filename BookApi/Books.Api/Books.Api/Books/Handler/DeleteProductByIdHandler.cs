using Catalog.API.Context;
using Catalog.API.Products.Command;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Products.Handler
{
    public class DeleteProductByIdHandler: IRequestHandler<DeleteProductByIdCommand, bool>
    {
        private readonly CatalogContext _context;
        public DeleteProductByIdHandler(CatalogContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == request.id);
            if(product == null) { return false; }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return true;
        }
    }
}
