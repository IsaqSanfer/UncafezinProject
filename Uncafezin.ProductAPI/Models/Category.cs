using System.ComponentModel.DataAnnotations;

namespace Uncafezin.ProductAPI.Models;

public class Category
{
    [Key] public int CategoryId { get; set; }

    [Required(ErrorMessage = "Nome obrigatório.")]
    [MinLength(3)]
    [MaxLength(50)]
    public string? Name { get; set; }

    public ICollection<Product>? Products { get; set;}
}