using Ambev.DeveloperEvaluation.Application.Product.CreateProduct;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData;

public static class CreateProductHandlerTestData
{

    private static readonly Faker<CreateProductCommand> createProductHandlerFaker = new Faker<CreateProductCommand>()
        .RuleFor(u => u.Title, f => f.Commerce.ProductName())
        .RuleFor(u => u.Price, f => f.Random.Decimal(0.01m, 9999999999999999.99m))
        .RuleFor(u => u.Description, f => f.Commerce.ProductDescription())
        .RuleFor(u => u.Category, f => f.Commerce.ProductAdjective())
        .RuleFor(u => u.Image, f => f.Image.ToString());

    public static CreateProductCommand GenerateValidCommand()
    {
        return createProductHandlerFaker.Generate();
    }
}
