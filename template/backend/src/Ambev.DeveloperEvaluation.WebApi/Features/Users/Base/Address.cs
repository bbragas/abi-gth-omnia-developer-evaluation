namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.Base;

public class Address
{
    public string City { get; set; } = String.Empty;
    public string Street { get; set; } = String.Empty;
    public int Number { get; set; }
    public string Zipcode { get; set; } = String.Empty;
    public Geolocation Geolocation { get; set; } = new Geolocation();
}
