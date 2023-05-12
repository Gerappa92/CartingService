using CartingService.BusinessLogic.Handlers;
using CartingService.Web.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CartingService.Web.Endpoints.Cart;

public class CartEndpoints
{
    /// <summary>
    /// Gets the cart info.
    /// </summary>
    /// <param name="cartId">The cart identifier.</param>
    /// <param name="mediator">The mediator.</param>
    /// <returns></returns>
    public async Task<IResult> GetCartInfo(
        [FromRoute] Guid cartId,
        [FromServices] IMediator mediator)
    {
        var query = new ListCartItemsQuery(cartId);
        var items = await mediator.Send(query);
        if (items is null)
        {
            return Results.NotFound();
        }
        var result = new GetCartInfoResult(cartId, items);
        return Results.Ok(result);
    }

    /// <summary>
    /// Adds the itemDto to cart.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="mediator">The mediator.</param>
    /// <returns></returns>
    public async Task<IResult> AddItemToCart(
        [FromBody] AddCartItemCommand command,
        [FromServices] IMediator mediator)
    {
        try
        {
            await mediator.Send(command);
        }
        catch (ValidationException e)
        {
            return Results.ValidationProblem(e.ToDictionary());
        }
        return Results.Ok();
    }


    /// <summary>
    /// Deletes the itemDto from cart.
    /// </summary>
    /// <param name="cartId">The cart identifier.</param>
    /// <param name="itemId">The itemDto identifier.</param>
    /// <param name="mediator">The mediator.</param>
    /// <returns></returns>
    public async Task<IResult> DeleteItemFromCart(
        [FromRoute] Guid cartId,
        [FromRoute] int itemId,
        [FromServices] IMediator mediator)
    {
        var command = new DeleteCartItemCommand(cartId, itemId);
        var isDeleted = await mediator.Send(command);

        return isDeleted ? Results.Ok() : Results.NotFound();
    }
}