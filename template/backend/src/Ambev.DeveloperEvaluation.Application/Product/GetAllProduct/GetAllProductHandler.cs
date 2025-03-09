using Ambev.DeveloperEvaluation.Application.Base;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR; 

namespace Ambev.DeveloperEvaluation.Application.Product.GetAllProduct
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductCommand, List<GetAllProductResult>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetAllProductHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _repository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllProductResult>> Handle(GetAllProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new GetAllProductCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);


            var orderbyLambda = Utils.OrderbyToLambda<Ambev.DeveloperEvaluation.Domain.Entities.Product>(command.OrderBy);
            var descending = Utils.OrderbyToDescending(command.OrderBy);

            var ProductsList =
                await _repository.GetAllPaginatedAsync(
                    command.PageNumber,
                    command.PageSize,
                    orderbyLambda,
                    descending,
                    cancellationToken);

            var result = _mapper.Map<List<GetAllProductResult>>(ProductsList);

            return result;
        }
    }
}
