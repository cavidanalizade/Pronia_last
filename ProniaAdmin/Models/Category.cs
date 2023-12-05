using System.ComponentModel.DataAnnotations;

namespace ProniaAdmin.Models
{
    public class Category
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 10, ErrorMessage = "Uzunlugu kecdiz")]
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
