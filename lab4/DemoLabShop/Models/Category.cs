namespace DemoLabShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Category> GetAll()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Áo dài" },
                new Category { Id = 2, Name = "Áo dông" },
                new Category { Id = 3, Name = "Túi xách" },
                new Category { Id = 4, Name = "Đồng hồ" },
                new Category { Id = 5, Name = "Ví da" },
                new Category { Id = 6, Name = "Thắt lưng da" },
                new Category { Id = 7, Name = "Tủ lạnh" },
                new Category { Id = 8, Name = "Tivi" },
                new Category { Id = 9, Name = "Quạt điện" },
                new Category { Id = 10, Name = "Lò sưởi" }
            };
        }
    }
}
