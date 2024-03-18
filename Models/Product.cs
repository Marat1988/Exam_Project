using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    public class Product
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Название должно содержать 50 символов")]
        [Index(IsUnique = true)]
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public byte[] Photo { get; set; }
    }
}