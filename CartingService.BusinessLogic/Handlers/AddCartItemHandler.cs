using CartingService.BusinessLogic.Models;
using MediatR;

namespace CartingService.BusinessLogic.Handlers;

public record AddCartItemCommand(Item Item) : IRequest;

public class AddCartItemHandler : IRequestHandler<AddCartItemCommand>
{
    public Task Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}