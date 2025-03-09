using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Cart.CreateCart;

public class CreateCartHandler : IRequestHandler<CreateCartCommand, CreateCartResult>
{
    private readonly ICartRepository _repository;
    private readonly IMapper _mapper;
    public CreateCartHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _repository = cartRepository;
        _mapper = mapper;
    }
    public async Task<CreateCartResult> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateCartCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = _mapper.Map<Ambev.DeveloperEvaluation.Domain.Entities.Cart>(command);

        Ambev.DeveloperEvaluation.Domain.Entities.Cart createdCart = await _repository.CreateAsync(cart, cancellationToken);
        var result = _mapper.Map<CreateCartResult>(createdCart);

        return result;
    }
}
