using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyApp.Data.Entities.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);
            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);
            builder.Property(x => x.Price)
                .HasColumnType("decimal(18,2)");
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();
            builder.HasData(
                 new Product { Id = 1, Name = "Smartphone X", Description = "Latest-gen smartphone with high-end features.", Price = 899.99m, CategoryId = 1 },
                 new Product { Id = 2, Name = "Wireless Headphones", Description = "Noise-cancelling over-ear headphones.", Price = 199.50m, CategoryId = 1 },
                 new Product { Id = 3, Name = "Men's T-Shirt", Description = "100% cotton casual t-shirt.", Price = 29.99m, CategoryId = 2 },
                 new Product { Id = 4, Name = "Non-Stick Frying Pan", Description = "Durable non-stick cookware for everyday use.", Price = 45.00m, CategoryId = 3 },
                 new Product { Id = 5, Name = "Yoga Mat", Description = "Anti-slip fitness mat for workouts.", Price = 25.75m, CategoryId = 4 },
                 new Product { Id = 6, Name = "Fantasy Novel", Description = "Bestselling adventure fantasy book.", Price = 15.99m, CategoryId = 5 },
                 new Product { Id = 7, Name = "Face Moisturizer", Description = "Hydrating skincare cream for daily use.", Price = 12.49m, CategoryId = 6 },
                 new Product { Id = 8, Name = "Kids Puzzle Set", Description = "Colorful puzzle set for early learning.", Price = 18.00m, CategoryId = 7 },
                 new Product { Id = 9, Name = "Car Phone Mount", Description = "Dashboard mount for smartphones.", Price = 9.99m, CategoryId = 8 },
                 new Product { Id = 10, Name = "Organic Olive Oil", Description = "Extra virgin olive oil for cooking.", Price = 7.99m, CategoryId = 9 }
            );

        }
    }
}