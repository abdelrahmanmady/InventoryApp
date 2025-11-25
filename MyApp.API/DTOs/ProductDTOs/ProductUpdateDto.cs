using System.ComponentModel.DataAnnotations;

namespace MyApp.API.DTOs.ProductDTOs
{
    public class ProductUpdateDto
    {
        public string? Name { get; set; } = null!;
        public string? Description { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "Price Must be greater than 0")]
        public decimal? Price { get; set; }
        public IFormFile? Image { get; set; }
        public int? CategoryId { get; set; }
    }
}
