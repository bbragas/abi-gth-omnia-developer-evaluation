using Ambev.DeveloperEvaluation.Application.Cart.CreateCart; 
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application;

public class CreateCartHandlerTests
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    private readonly CreateCartHandler _handler;


    public CreateCartHandlerTests()
    {
        _cartRepository = Substitute.For<ICartRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateCartHandler(_cartRepository, _mapper);
    }

    [Fact]
    public async Task Handle_ValidRequest_ReturnsSuccessResponse()
    {
        var command = CreateCartHandlerTestData.GenerateValidCommand();
        var Cart = new Cart
        {
            Id = ((int)Random.Shared.NextInt64()),
            Date = DateTime.UtcNow,
            UserId = command.UserId,
            CartItems = command.CartItems,
            WasSold = true

        };

        var result = new CreateCartResult
        {
            Id = Cart.Id
        };

        _mapper.Map<Cart>(command).Returns(Cart);
        _mapper.Map<CreateCartResult>(Cart).Returns(result);

        _cartRepository.CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>())
            .Returns(Cart);

        var createCartResult = await _handler.Handle(command, CancellationToken.None);

        createCartResult.Should().NotBeNull();
        createCartResult.Id.Should().Be(Cart.Id);
        await _cartRepository.Received(1).CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>());
    }


    [Fact]
    public async Task Handle_InvalidRequest_ThrowsValidationException()
    {
        var command = new CreateCartCommand();

        var act = () => _handler.Handle(command, CancellationToken.None);

        await act.Should().ThrowAsync<FluentValidation.ValidationException>();
    }


    [Fact]
    public async Task Handle_ValidRequest_MapsCommandToCart()
    {
        var command = CreateCartHandlerTestData.GenerateValidCommand();
        var Cart = new Cart
        {
            Id = ((int)Random.Shared.NextInt64()),
            Date = DateTime.UtcNow,
            UserId = command.UserId,
            CartItems = command.CartItems,
            WasSold = true
        };

        _mapper.Map<Cart>(command).Returns(Cart);
        _cartRepository.CreateAsync(Arg.Any<Cart>(), Arg.Any<CancellationToken>())
            .Returns(Cart);

        await _handler.Handle(command, CancellationToken.None);

        _mapper.Received(1).Map<Cart>(Arg.Is<CreateCartCommand>(c =>
            c.UserId == command.UserId &&
            c.Date == command.Date &&
            c.CartItems == command.CartItems));
    }
}
