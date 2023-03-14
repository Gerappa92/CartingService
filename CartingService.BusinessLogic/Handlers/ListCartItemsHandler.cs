using CartingService.BusinessLogic.Models;
using MediatR;

namespace CartingService.BusinessLogic.Handlers;

public record ListCartItemsQuery(Guid CartId) : IRequest<IEnumerable<Item>>;

public class ListCartItemsHandler : IRequestHandler<ListCartItemsQuery, IEnumerable<Item>>
{
    public Task<IEnumerable<Item>> Handle(ListCartItemsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}