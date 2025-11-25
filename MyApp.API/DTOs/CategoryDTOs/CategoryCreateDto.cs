namespace MyApp.API.DTOs.CategoryDTOs
{
    public class CategoryCreateDto
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
