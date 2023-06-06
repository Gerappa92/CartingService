using CartingService.DataAccess.Repositories;
using FluentValidation;
using MediatR;

namespace CartingService.BusinessLogic.Handlers;

public record UpdateItemRequest(int ItemId, string Name, decimal Price) : IRequest<int>;

public class UpdateItemHandler : IRequestHandler<UpdateItemRequest, int>
{
    private readonly ICartRepository _cartRepository;
    private readonly IValidator<UpdateItemRequest> _validator;

    public UpdateItemHandler(ICartRepository cartRepository, IValidator<UpdateItemRequest> validator)
    {
        _cartRepository = cartRepository;
        _validator = validator;
    }

    public Task<int> Handle(UpdateItemRequest request, CancellationToken cancellationToken)
    {
        ValidateAndThrow(request);
        var updatedCount = _cartRepository.UpdateItem(request.ItemId, request.Name, request.Price);
        
        return Task.FromResult(updatedCount);
    }

    private void ValidateAndThrow(UpdateItemRequest request)
    {
        var validationResult = _validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    }
}