using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.Query
{
    public class GetProductByIdQuery : IRequest<Book>
    {
        public int Id{ get; set;}
        public GetProductByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}
