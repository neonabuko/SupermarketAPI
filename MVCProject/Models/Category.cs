using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models;

public class Category
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }

    [StringLength(100)]
    public string? Description { get; set; }
}