using System.ComponentModel.DataAnnotations;

namespace ShopAPI.Model;

public class Customer
{
    public int Id { get; set; }

    [MinLength(3)]
    public required string Name { get; set; }

    [EmailAddress]
    public string? EMailAddress { get; set; }
    
    public bool HasBackPayments { get; set; }
}