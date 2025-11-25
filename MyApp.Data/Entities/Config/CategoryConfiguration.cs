using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyApp.Data.Entities.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);
            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);
            builder.HasData(
                     new Category { Id = 1, Name = "Electronics", Description = "Devices, gadgets, and smart technology products." },
                     new Category { Id = 2, Name = "Clothing", Description = "Fashion apparel for men, women, and children." },
                     new Category { Id = 3, Name = "Home & Kitchen", Description = "Household essentials, cookware, and home accessories." },
                     new Category { Id = 4, Name = "Sports", Description = "Sporting goods, fitness equipment, and outdoor gear." },
                     new Category { Id = 5, Name = "Books", Description = "Printed and digital books across various genres." },
                     new Category { Id = 6, Name = "Beauty", Description = "Cosmetics, skincare, and beauty care products." },
                     new Category { Id = 7, Name = "Toys", Description = "Toys, games, and educational products for kids." },
                     new Category { Id = 8, Name = "Automotive", Description = "Car accessories, maintenance supplies, and tools." },
                     new Category { Id = 9, Name = "Groceries", Description = "Everyday food items, beverages, and household necessities." },
                     new Category { Id = 10, Name = "Accessories", Description = "Fashion accessories including bags, belts, and jewelry." }
            );
        }
    }
}