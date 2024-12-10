using FluentValidation;

namespace Catalog.API.Products.Command
{
    public class CreateProductCommandValidator: AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be Empty");
            RuleFor(x => x.ImageFile).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price Cannot be Negative");
            RuleFor(x=> x.Category).NotEmpty();
        }
    }
}
