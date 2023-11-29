using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Uncafezin.WebAppUltimate.Models;

public class ProductViewModel
{
    [DisplayName("COD")]
    public int Id { get; set; }

    [Required]
    [DisplayName("Produto")]
    public string? Name { get; set; }

    [Required]
    [DisplayName("Preço")]
    public decimal Price { get; set; }

    [Required]
    [DisplayName("Descrição")]
    public string? Description { get; set; }

    [Required]
    [DisplayName("Quantidade")]
    public int Stock { get; set; }

    [Required]
    [DisplayName("Imagem")]
    public string? ImgUrl { get; set; }

    [DisplayName("#CATG")]
    public int CategoryId { get; set; }

    [DisplayName("Categoria")]
    public string? CategoryName { get; set; }
}
