using Ambev.DeveloperEvaluation.Application.Base;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Application.Users.GetAllUser;
public class GetAllUserHandler : IRequestHandler<GetAllUserCommand, List<GetAllUserResult>>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public GetAllUserHandler(IUserRepository UserRepository, IMapper mapper)
    {
        _repository = UserRepository;
        _mapper = mapper;
    }
    public async Task<List<GetAllUserResult>> Handle(GetAllUserCommand command, CancellationToken cancellationToken)
    {
        var validator = new GetAllUserCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);


        var orderbyLambda = Utils.OrderbyToLambda<User>(command.OrderBy);
        var descending = Utils.OrderbyToDescending(command.OrderBy);

        var UsersList =
            await _repository.GetAllPaginatedAsync(
                command.PageNumber,
                command.PageSize,
                orderbyLambda,
                descending,
                cancellationToken);

        var result = _mapper.Map<List<GetAllUserResult>>(UsersList);

        return result;
    }
}