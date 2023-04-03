namespace CartingService.Web.Endpoints.Cart;

public static class CartEndpointsRegistration
{
    public static void RegisterCartEndpoints(this WebApplication app)
    {
        CartEndpoints cartEndpoints = new();
        var cartV1 = app.MapGroup("/v1.0/cart");

        cartV1.MapGet("{cartId:guid}", cartEndpoints.GetCartInfo)
            .WithName(nameof(cartEndpoints.GetCartInfo))
            .Produces<GetCartInfoResult>()
            .WithOpenApi();
        cartV1.MapPost(string.Empty, cartEndpoints.AddItemToCart)
            .WithName(nameof(cartEndpoints.AddItemToCart))
            .WithOpenApi();
        cartV1.MapDelete("{cartId:guid}/items/{itemId:int}", cartEndpoints.DeleteItemFromCart)
            .WithName(nameof(cartEndpoints.DeleteItemFromCart))
            .WithOpenApi();
    }
}