using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Cart.GetCart;

public class GetCartHandler : IRequestHandler<GetCartCommand, GetCartResult>
{
    private readonly ICartRepository _repository;
    private readonly IMapper _mapper;
    public GetCartHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _repository = cartRepository;
        _mapper = mapper;
    }
    public async Task<GetCartResult> Handle(GetCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new GetCartCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = await _repository.GetByIdAsync(command.Id, cancellationToken);
        if (cart == null)
            throw new KeyNotFoundException($"ID {command.Id} not found");

        return _mapper.Map<GetCartResult>(cart);
    }
}