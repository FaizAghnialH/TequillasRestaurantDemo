using System.ComponentModel;

namespace TequillasRestaurant.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId {  get; set; }
        public Category? Category {  get; set; } // a product beloing to catogory
        public ICollection<OrderItem>? OrderItems { get; set; } // a product can be in many order items 
        public ICollection<ProductIngredient>? ProductsIngredients { get; set; } // a product can have many ingredients 


    }
}