using Catalog.API.Context;
using Catalog.API.Models;
using Catalog.API.Products.Command;
using FluentValidation;
using Mapster;
using MediatR;

namespace Catalog.API.Products.Handler
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
    {
        private readonly CatalogContext _context;
        private readonly IValidator<CreateProductCommand> _validator;
        public CreateProductHandler(CatalogContext context, IValidator<CreateProductCommand> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            var errors = validationResult.Errors.ToList();
            if(errors.Any()) { throw new ValidationException(errors); }

            var product = request.Adapt<Book>();
            product.Id = _context.Products.Count() + 1;
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return new CreateProductResponse { Id = product.Id };
        }
    }
}
