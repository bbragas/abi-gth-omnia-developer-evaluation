using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetAllProductFiltredByCategory
{
    public class GetAllProductFiltredByCategoryHandler : IRequestHandler<GetAllProductFiltredByCategoryCommand, List<GetAllProductFiltredByCategoryResult>>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public GetAllProductFiltredByCategoryHandler(IProductRepository ProductRepository, IMapper mapper)
        {
            _repository = ProductRepository;
            _mapper = mapper;
        }
        public async Task<List<GetAllProductFiltredByCategoryResult>> Handle(GetAllProductFiltredByCategoryCommand command, CancellationToken cancellationToken)
        {
            var validator = new GetAllProductFiltredByCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var ProductsList =
                await _repository.GetAllPaginatedFiltredByCategoryAsync(
                    command.PageNumber,
                    command.PageSize,
                    command.Category,
                    cancellationToken);

            var result = _mapper.Map<List<GetAllProductFiltredByCategoryResult>>(ProductsList);

            return result;
        }
    }
}
