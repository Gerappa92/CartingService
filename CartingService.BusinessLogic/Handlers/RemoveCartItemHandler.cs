using CartingService.DataAccess.Repositories;
using MediatR;

namespace CartingService.BusinessLogic.Handlers;

public record RemoveCartItemCommand(Guid CartId, Guid ItemId) : IRequest;

public class RemoveCartItemHandler : IRequestHandler<RemoveCartItemCommand>
{
    private readonly ICartRepository _cartRepository;

    public RemoveCartItemHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Task Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
    {
        _cartRepository.RemoveItem(request.CartId, request.ItemId);
        return Unit.Task;
    }
}