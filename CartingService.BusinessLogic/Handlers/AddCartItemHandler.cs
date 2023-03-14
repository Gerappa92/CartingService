using CartingService.BusinessLogic.Mappings;
using CartingService.BusinessLogic.Models;
using CartingService.DataAccess.Repositories;
using MediatR;

namespace CartingService.BusinessLogic.Handlers;

public record AddCartItemCommand(Guid CartId, Item Item) : IRequest;

public class AddCartItemHandler : IRequestHandler<AddCartItemCommand>
{
    private readonly ICartRepository _cartRepository;

    public AddCartItemHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Task Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var item = request.Item.Map();
        _cartRepository.AddItem(request.CartId, item);
        return Unit.Task;
    }
}