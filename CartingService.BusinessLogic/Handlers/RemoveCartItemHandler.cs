using MediatR;

namespace CartingService.BusinessLogic.Handlers;

public record RemoveCartItemCommand(Guid CartId, Guid ItemId) : IRequest;

public class RemoveCartItemHandler : IRequestHandler<RemoveCartItemCommand>
{
    public Task Handle(RemoveCartItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}