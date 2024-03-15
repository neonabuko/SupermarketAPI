using System.ComponentModel.DataAnnotations;
using MVCProject.Models;

namespace MVCProject;

public record CategoryDto(
    int Id,
    string Name,
    string? Description,
    ICollection<Product>? Products
    );

public record ProductDto(
    int Id,
    string Name,
    decimal Price
    );
    