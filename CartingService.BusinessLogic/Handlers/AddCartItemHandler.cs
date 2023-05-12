using CartingService.BusinessLogic.Mappings;
using CartingService.BusinessLogic.Models;
using CartingService.DataAccess.Repositories;
using FluentValidation;
using MediatR;

namespace CartingService.BusinessLogic.Handlers;

public record AddCartItemCommand(Guid CartId, ItemDto ItemDto) : IRequest;

public class AddCartItemHandler : IRequestHandler<AddCartItemCommand>
{
    private readonly ICartRepository _cartRepository;
    private readonly IValidator<ItemDto> _validator;

    public AddCartItemHandler(ICartRepository cartRepository, IValidator<ItemDto> validator)
    {
        _cartRepository = cartRepository;
        _validator = validator;
    }

    public Task Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        ValidateAndThrow(request);

        var item = request.ItemDto.Map();
        _cartRepository.AddItem(request.CartId, item);
        return Unit.Task;
    }

    private void ValidateAndThrow(AddCartItemCommand request)
    {
        var validationResult = _validator.Validate(request.ItemDto);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    }
}