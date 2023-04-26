using CartingService.DataAccess.Repositories;
using MediatR;

namespace CartingService.BusinessLogic.Handlers;

public record DeleteCartItemCommand(Guid CartId, int ItemId) : IRequest<bool>;

public class DeleteCartItemHandler : IRequestHandler<DeleteCartItemCommand, bool>
{
    private readonly ICartRepository _cartRepository;

    public DeleteCartItemHandler(ICartRepository cartRepository)
    {
        _cartRepository = cartRepository;
    }

    public Task<bool> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        var deleted = _cartRepository.RemoveItem(request.CartId, request.ItemId);
        return Task.FromResult(deleted);
    }
}