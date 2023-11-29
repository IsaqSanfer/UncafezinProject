using System.ComponentModel.DataAnnotations;

namespace Uncafezin.WebApp.Models;

public class ProductViewModel
{
    public int Id { get; set; }
        
    [Required]
    public string? Name { get; set; }

    [Required]
    public int Price { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required]
    public int Stock { get; set; }

    [Required]
    public string? ImgUrl { get; set; }
    public string? CategoryName { get; set; }
    public int CategoryId { get; set; }
}