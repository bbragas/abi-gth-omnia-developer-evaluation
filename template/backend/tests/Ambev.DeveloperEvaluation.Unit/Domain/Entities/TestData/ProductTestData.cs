using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;

public static class ProductTestData
{
   
    private static readonly Faker<Product> ProductFaker = new Faker<Product>()
        .RuleFor(u => u.Title, f => f.Commerce.ProductName())
        .RuleFor(u => u.Price, f => f.Random.Decimal(0.01m, 9999999999999999.99m))
        .RuleFor(u => u.Description, f => f.Commerce.ProductDescription())
        .RuleFor(u => u.Category, f => f.Commerce.ProductAdjective())
        .RuleFor(u => u.Image, f => f.Image.ToString());

    public static Product GenerateValidProduct()
    {
        return ProductFaker.Generate();
    }


    public static decimal GenerateValidUnitprice()
    {
        var faker = new Faker();
        return faker.Random.Decimal(0.01m, 9999999999999999.99m);
    }

    public static string GenerateValidProductname()
    {
        return new Faker().Commerce.ProductName();
    }

    public static decimal GenerateInvalidUnitprice()
    {
        return new Faker().Random.Decimal(-0.02m, -0.01m);
    }

    public static string GenerateLongProductname()
    {
        return new Faker().Random.String2(51);
    }
}
