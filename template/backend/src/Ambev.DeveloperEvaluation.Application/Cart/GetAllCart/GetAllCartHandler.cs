using Ambev.DeveloperEvaluation.Application.Base;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;


namespace Ambev.DeveloperEvaluation.Application.Cart.GetAllCart;

public class GetAllCartHandler : IRequestHandler<GetAllCartCommand, List<GetAllCartResult>>
{
    private readonly ICartRepository _repository;
    private readonly IMapper _mapper;
    public GetAllCartHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _repository = cartRepository;
        _mapper = mapper;
    }
    public async Task<List<GetAllCartResult>> Handle(GetAllCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new GetAllCartCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var orderbyLambda = Utils.OrderbyToLambda<Ambev.DeveloperEvaluation.Domain.Entities.Cart>(command.OrderBy);
        var descending = Utils.OrderbyToDescending(command.OrderBy);

        var cartsList =
            await _repository.GetAllPaginatedAsync(
                command.PageNumber,
                command.PageSize,
                orderbyLambda,
                descending,
                cancellationToken);

        var result = _mapper.Map<List<GetAllCartResult>>(cartsList);

        return result;
    }
}
