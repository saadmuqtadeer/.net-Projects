using Carter;
using Catalog.API.Products.Command;
using Catalog.API.Products.Handler;
using Catalog.API.Products.Query;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Catalog.API.Products.Handler.UpdateProductHandler;

namespace Catalog.API.Products.CreateProduct
{
    public class EndPoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductCommand request, ISender sender) =>
            {
                var command = request.Adapt<CreateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateProductResponse>();
                return Results.Created($"/product/{response.Id}", response);
            });

            app.MapGet("/products", async (ISender sender) =>
            {
                var query = new GetAllProductQuery();
                var products = await sender.Send(query);
                return Results.Ok(products);
            });

            app.MapGet("/product/{id}", async (int id, ISender sender) =>
            {
                var request = new GetProductByIdQuery(id);
                var product = await sender.Send(request);
                return Results.Ok(product);
            });

            app.MapDelete("/product/{id}", async (int id, ISender sender) =>
            {
                var request = new DeleteProductByIdCommand(id);
                var isDeleted = await sender.Send(request);
                return Results.Ok(isDeleted);
            });

            app.MapPut("/product", async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductByIdCommand>();
                var isUpdated = await sender.Send(command);
                return Results.Ok(isUpdated);
            });
        }
    };
}
