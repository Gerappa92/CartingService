using CartingService.BusinessLogic.Handlers;
using CartingService.BusinessLogic.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Web.Endpoints;

public static class CartEndpoints
{
    public static void RegisterCartEndpoints(this WebApplication app)
    {
        var cartGroup = app.MapGroup("api/v1.0/cart");
        cartGroup.MapGet("{cartId:guid}", GetCartInfo)
            .WithName(nameof(GetCartInfo))
            .WithOpenApi();
        cartGroup.MapPost(string.Empty, AddItemToCart)
            .WithName(nameof(AddItemToCart))
            .WithOpenApi();
        cartGroup.MapDelete("{cartId:guid}/items/{itemId:int}", DeleteItemFromCart)
            .WithName(nameof(DeleteItemFromCart))
            .WithOpenApi();
    }

    private static async Task<IResult> GetCartInfo(
        [FromRoute] Guid cartId,
        [FromServices] IMediator mediator)
    {
        var query = new ListCartItemsQuery(cartId);
        var items = await mediator.Send(query);
        var result = new GetCartInfoResult(cartId, items);
        return Results.Ok(result);
    }

    private static async Task<IResult> AddItemToCart(
        [FromBody] AddCartItemCommand command,
        [FromServices] IMediator mediator)
    {
        await mediator.Send(command);
        // TODO: Check validation
        // TODO: Check if created
        return Results.Ok();
    }

    private static async Task<IResult> DeleteItemFromCart(
        [FromRoute] Guid cartId,
        [FromRoute] int itemId,
        [FromServices] IMediator mediator)
    {
        var command = new DeleteCartItemCommand(cartId, itemId);
        await mediator.Send(command);
        // TODO: check if deleted
        return Results.Ok();
    }

}

internal record GetCartInfoResult(Guid CartId, IEnumerable<Item> Items);