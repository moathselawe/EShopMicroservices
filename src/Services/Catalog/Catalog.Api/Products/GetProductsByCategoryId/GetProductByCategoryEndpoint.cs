namespace Catalog.Api.Products.GetProductByCategory;
public record GetProductByCategoryResponse(IEnumerable<Product> Product);
public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async(string category, ISender sender) =>
        {
            var product = await sender.Send(new GetProductByCategoryQuery(category));
            var response = product.Adapt<GetProductByCategoryResponse>();
            return Results.Ok(response);
        }).WithName("GetProductByCategory")
        .Produces<GetProductByCategoryResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Category")
        .WithDescription("Get Product By Category");
    }
}
