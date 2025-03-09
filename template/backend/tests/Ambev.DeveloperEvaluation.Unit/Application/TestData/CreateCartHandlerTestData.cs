using Ambev.DeveloperEvaluation.Application.Cart.CreateCart;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

public static class  CreateCartHandlerTestData
{
    private static readonly Faker<CreateCartCommand> createCustomerHandlerFaker = new Faker<CreateCartCommand>()
        .RuleFor(u => u.UserId, f => f.UniqueIndex)
        .RuleFor(u => u.Date, f => f.DateTimeReference);


    public static CreateCartCommand GenerateValidCommand()
    {
        return createCustomerHandlerFaker.Generate();
    }
}
