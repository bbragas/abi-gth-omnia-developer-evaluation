using Ambev.DeveloperEvaluation.Application.Product.CreateProduct;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;
public class CreateProductHandlerTests
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly CreateProductHandler _handler;


    public CreateProductHandlerTests()
    {
        _productRepository = Substitute.For<IProductRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateProductHandler(_productRepository, _mapper);
    }

    [Fact]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        var command = CreateProductHandlerTestData.GenerateValidCommand();
        var product = new Product
        {
            Id = ((int)Random.Shared.NextInt64()),
            Title = command.Title,
            Description = command.Description,
            Category = command.Category,
            Image = command.Image,
            Price = command.Price,
            Rating = command.Rating
        };

        var result = new CreateProductResult
        {
            Id = product.Id
        };

        _mapper.Map<Product>(command).Returns(product);
        _mapper.Map<CreateProductResult>(product).Returns(result);

        _productRepository.CreateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>())
            .Returns(product);

        var createProductResult = await _handler.Handle(command, CancellationToken.None);

        createProductResult.Should().NotBeNull();
        createProductResult.Id.Should().Be(product.Id);
        await _productRepository.Received(1).CreateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>());
    }


    [Fact]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        var command = new CreateProductCommand(); 

        var act = () => _handler.Handle(command, CancellationToken.None);
       
        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }

 
    [Fact]
    public async Task Handle_ValidRequest_MapsCommandToProduct()
    {
        var command = CreateProductHandlerTestData.GenerateValidCommand();
        var product = new Product
        {
            Id = ((int)Random.Shared.NextInt64()),
            Title = command.Title,
            Description = command.Description,
            Category = command.Category,
            Image = command.Image,
            Price = command.Price,
            Rating = command.Rating
        };

        _mapper.Map<Product>(command).Returns(product);
        _productRepository.CreateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>())
            .Returns(product);

        await _handler.Handle(command, CancellationToken.None);

        _mapper.Received(1).Map<Product>(Arg.Is<CreateProductCommand>(c =>
            c.Title == command.Title &&
            c.Description == command.Description &&
            c.Category == command.Category &&
            c.Image == command.Image &&
            c.Price == command.Price &&
            c.Rating == command.Rating));
    }
}
