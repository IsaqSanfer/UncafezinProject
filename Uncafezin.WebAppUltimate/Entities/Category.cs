using System.ComponentModel.DataAnnotations;

namespace Uncafezin.WebAppUltimate.Entities;

public class Category
{
    [Key] public int CategoryId { get; set; }

    [Required(ErrorMessage = "Nome obrigatório.")]
    [MinLength(3)]
    [MaxLength(50)]
    public string? CategoryName { get; set; }

    public ICollection<Product>? Products { get; set; }
}
