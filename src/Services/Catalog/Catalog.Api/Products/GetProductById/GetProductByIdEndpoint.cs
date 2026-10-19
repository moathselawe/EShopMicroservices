namespace Catalog.Api.Products.GetProductById;

public record GetProductByIdResponse(Product Product);
public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{Id}", async (Guid Id, ISender sender) =>
        {
            var product = await sender.Send(new GetProductByIdQuery(Id));

            var result = product.Adapt<GetProductByIdResponse>();

            return Results.Ok(result);

        }).WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}
