
namespace MVCProject.Models;

public static class EntityExtensions
{
    public static CategoryDto AsDto(this Category category)
    {
        return new CategoryDto(
            category.Id,
            category.Name,
            category.Description);
    }
}