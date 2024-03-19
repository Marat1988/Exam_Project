using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Название должно содержать 50 символов")]
        [Index(IsUnique = true)]
        [Required]
        [Display(Name = "Наименование поставщика")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}