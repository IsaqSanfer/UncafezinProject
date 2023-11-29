using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Uncafezin.WebAppUltimate.Models;

public class CategoryViewModel
{
    [DisplayName("#CATG")]
    [Key]public int CategoryId { get; set; }

    [DisplayName("Categoria")]
    public string? CategoryName { get; set; }
}
