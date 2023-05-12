﻿using CartingService.BusinessLogic.Mappings;
using CartingService.BusinessLogic.Models;
using CartingService.DataAccess.Repositories;
using MediatR;

namespace CartingService.BusinessLogic.Handlers;

public record ListCartItemsQuery(Guid CartId) : IRequest<IEnumerable<ItemDto>>;

public class ListCartItemsHandler : IRequestHandler<ListCartItemsQuery, IEnumerable<ItemDto>>
{
    private readonly ICartRepository _cartRepository;

    public ListCartItemsHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Task<IEnumerable<ItemDto>> Handle(ListCartItemsQuery request, CancellationToken cancellationToken)
    {
        var items = _cartRepository.ListItems(request.CartId);
        return Task.FromResult(items?.Map());
    }
}