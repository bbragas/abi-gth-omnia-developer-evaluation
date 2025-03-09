using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Cart.GetAllCart;

public class GetAllCartResult
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime Date { get; set; }

    public List<CartItem>? CartItems { get; set; }
}
