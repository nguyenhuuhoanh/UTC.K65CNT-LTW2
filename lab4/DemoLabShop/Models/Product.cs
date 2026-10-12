namespace DemoLabShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public static List<Product> GetNewProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/noicom1.jpg", Price = 2850000, CategoryId = 7 },
                new Product { Id = 2, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/noicom2.jpg", Price = 2850000, CategoryId = 7 },
                new Product { Id = 3, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/noicom3.jpg", Price = 2850000, CategoryId = 7 }
            };
        }

        public static List<Product> GetHotProducts()
        {
            return new List<Product>
            {
                new Product { Id = 4, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/noicom4.jpg", Price = 2850000, CategoryId = 7 },
                new Product { Id = 5, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/noicom5.jpg", Price = 2850000, CategoryId = 7 },
                new Product { Id = 6, Name = "Nồi cơm điện cao tần Nagakawa NAG0102", Image = "/images/products/noicom6.jpg", Price = 2850000, CategoryId = 7 }
            };
        }
    }
}
