using System.ComponentModel.DataAnnotations;
using MVCProject.Models;

namespace MVCProject;

public record CategoryDto(
    int Id,
    string Name,
    string? Description
    );

public record ProductDto(
    int Id,
    string Name,
    decimal Price
    );

public record CreateCategoryDto(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(100)] string Description); 
    
public record UpdateCategoryDto(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(100)] string Description);
    