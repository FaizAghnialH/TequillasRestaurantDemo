using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TequillasRestaurant.Models;

namespace TequillasRestaurant.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<ProductIngredient> ProductsIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            base.OnModelCreating(ModelBuilder);


            //Define composite key & relationships tables
            ModelBuilder.Entity<ProductIngredient>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });

            ModelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductsIngredients)
                .HasForeignKey(pi => pi.ProductId);

            ModelBuilder.Entity<ProductIngredient>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);


            //seed data : untuk mengisi initial data dengan data dummy
            ModelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Appetizer", Description = "Appetizer product"},
                new Category { CategoryId = 2, Name = "Entree", Description = "Entree product" },
                new Category { CategoryId = 3, Name = "Side dish", Description = "Sidedish product" },
                new Category { CategoryId = 4, Name = "Dessert", Description = "Dessert product" },
                new Category { CategoryId = 5, Name = "Beverage", Description = "Beverage product" }
           );

            ModelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientId = 1, Name = "Beef" ,Description = "Beef Ingredient" },
                new Ingredient { IngredientId = 2, Name = "Chicken" ,Description = "Chicken Ingredient" },
                new Ingredient { IngredientId = 3, Name = "Fish" ,Description = "Fish Ingredient" },
                new Ingredient { IngredientId = 4, Name = "Tortilla" ,Description = "Tortilla product" },
                new Ingredient { IngredientId = 5, Name = "Tomato" ,Description = "Tomato Ingredient" },
                new Ingredient { IngredientId = 6, Name = "Lettuce" ,Description = "Lettuce Ingredient" }
                
           );

            ModelBuilder.Entity<Product>().HasData(

                //ADD mexican food entries here
                new Product
                { 
                    ProductId = 1,
                    Name = "Beef taco",
                    Description = "Delicious beef taco",
                    Price = 2.50m,
                    Stock = 100,
                    CategoryId = 2,
                },

                new Product
                {
                    ProductId = 2,
                    Name = "Chicken taco",
                    Description = "Delicious chicken taco",
                    Price = 1.99m,
                    Stock = 101,
                    CategoryId = 2,
                },

                new Product
                {
                    ProductId = 3,
                    Name = "Fish taco",
                    Description = "Delicious fish taco",
                    Price = 3.99m,
                    Stock = 90,
                    CategoryId = 2,
                }
            );

            ModelBuilder.Entity<ProductIngredient>().HasData(

                // bahan baku untuk beef taco ada: beef, tortilla, lettuce, tomato
                new ProductIngredient { ProductId = 1, IngredientId = 1},
                new ProductIngredient { ProductId = 1, IngredientId = 4},
                new ProductIngredient { ProductId = 1, IngredientId = 5},
                new ProductIngredient { ProductId = 1, IngredientId = 6},

                // bahan baku untuk chicken taco ada: chicken, tortilla, lettuce, tomato
                new ProductIngredient { ProductId = 2, IngredientId = 2 },
                new ProductIngredient { ProductId = 2, IngredientId = 4 },
                new ProductIngredient { ProductId = 2, IngredientId = 5 },
                new ProductIngredient { ProductId = 2, IngredientId = 6 },

                // bahan baku untuk fish taco ada: fish, tortilla, lettuce, tomato
                new ProductIngredient { ProductId = 3, IngredientId = 3 },
                new ProductIngredient { ProductId = 3, IngredientId = 4 },
                new ProductIngredient { ProductId = 3, IngredientId = 5 },
                new ProductIngredient { ProductId = 3, IngredientId = 6 }
            );
        }


    }
}
