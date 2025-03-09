namespace Ambev.DeveloperEvaluation.WebApi.Features.Cart.GetAllCart;

public class GetAllCartRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string OrderBy { get; set; } = string.Empty;
}
