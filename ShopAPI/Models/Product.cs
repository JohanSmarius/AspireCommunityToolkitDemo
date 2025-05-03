using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Model;

public class Product
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [MinLength(8)]
    public string? EanCode { get; set; }

    public decimal Price { get; set; }
    
    public decimal Weight { get; set; }
}