
using System.ComponentModel.DataAnnotations;
namespace PosBackend.models;
public class Product
{
    [Key]

    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }
    [Required]
    public double buyPrice { get; set; }
    [Required]
    public int quant { get; set; }
    [Required]
    public double sellPrice { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
}