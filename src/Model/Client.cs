using System.ComponentModel.DataAnnotations;

namespace Model;
public class Client
{
    public int ClientID { get; set; }

    [Required]
    public string? Name { get; set; }

    public List<Order>? Items { get; set; }
}