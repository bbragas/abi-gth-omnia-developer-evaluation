using Ambev.DeveloperEvaluation.WebApi.Features.Cart.Base;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.UpdateCart;
public class UpdateCartResponse
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public List<CartItem>? Products { get; set; }
}