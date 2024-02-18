using NBP.Domain.Entities;

namespace NBP.Domain.Identity;

public class Seller : User
{
    public ICollection<Product> Products { get; set; } = new List<Product>();

}