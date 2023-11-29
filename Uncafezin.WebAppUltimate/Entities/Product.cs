using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Uncafezin.WebAppUltimate.Entities;

public class Product
{
    [Key] public int Id { get; set; }

    [Required(ErrorMessage = "Nome obrigatório.")]
    [MinLength(3)]
    [MaxLength(50)]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Preço obrigatório.")]
    [Column(TypeName = "decimal(8,2)")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Descrição obrigatória.")]
    [MinLength(5)]
    [MaxLength(255)]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Estoque obrigatório.")]
    [Range(1, 1000)]
    public int Stock { get; set; }
    public string? ImgUrl { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }

    [ForeignKey("Category")]
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
}
