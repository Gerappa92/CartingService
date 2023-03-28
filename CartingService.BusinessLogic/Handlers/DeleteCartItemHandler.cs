using CartingService.DataAccess.Repositories;
using MediatR;

namespace CartingService.BusinessLogic.Handlers;

public record DeleteCartItemCommand(Guid CartId, int ItemId) : IRequest;

public class DeleteCartItemHandler : IRequestHandler<DeleteCartItemCommand>
{
    private readonly ICartRepository _cartRepository;

    public DeleteCartItemHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Task Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        _cartRepository.RemoveItem(request.CartId, request.ItemId);
        return Unit.Task;
    }
}