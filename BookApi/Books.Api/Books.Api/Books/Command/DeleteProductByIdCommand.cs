using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.Command
{
    public class DeleteProductByIdCommand: IRequest<bool>
    {
        public int id;
        public DeleteProductByIdCommand(int id)
        {
            this.id = id;
        }

    }
}
