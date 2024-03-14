using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models;

public class Product
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    
    [Required]
    [Range(1, 10000)]
    public required decimal Price { get; set; }

    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}