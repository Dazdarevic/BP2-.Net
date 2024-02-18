using NBP.Domain.Identity;
using System.ComponentModel.DataAnnotations;

namespace NBP.Domain.Entities;

public class Product
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Price { get; set; }
    // za sliku
    public string? Url { get; set; }
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }

    public int SellerId { get; set; }
    public Seller? Seller { get; set; }

}