using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.Query
{
    public class GetAllProductQuery: IRequest<IEnumerable<Book>>
    {
    }
}
