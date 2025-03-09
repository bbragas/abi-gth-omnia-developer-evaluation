using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Rating : BaseEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public decimal Rate { get; set; }
    public int Count { get; set; }
}
