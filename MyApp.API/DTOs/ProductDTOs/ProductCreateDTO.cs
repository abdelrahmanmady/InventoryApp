using System.ComponentModel.DataAnnotations;

namespace MyApp.API.DTOs.ProductDTOs
{
    public class ProductCreateDTO
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price Must be greater than 0")]
        public decimal? Price { get; set; }
        public IFormFile? Image { get; set; }

        [Required]
        public int? CategoryId { get; set; }
    }
}
