using System.ComponentModel.DataAnnotations;

namespace Lab04_DbFirst.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    }
}
