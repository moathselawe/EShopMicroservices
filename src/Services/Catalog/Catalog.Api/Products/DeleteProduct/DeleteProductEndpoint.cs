using Catalog.Api.Features.CreateProduct;

namespace Catalog.Api.Products.DeleteProduct;
public record DeleteProductRequest(Guid Id);
public record DeleteProductResponse(bool ISuccess);
public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
        {
            var command = new DeleteProductCommand(id);

            var result = await sender.Send(command);

            var response = new DeleteProductResponse(result.ISuccess);

            return Results.Ok(result);
        }
        ).WithName("DeleteProduct")
        .Produces<DeleteProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");  
    }
}
