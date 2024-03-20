using System.Collections.Generic;
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
        [Display(Name = "Наименование товара")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Цена товара")]
        public decimal Price { get; set; }
        [Display(Name = "Фотография товара")]
        public byte[] Photo { get; set; }

        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        [Display(Name = "Группа товара")]
        public virtual Group Group { get; set; }

        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        [Display(Name = "Поставщик товара")]
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<LineOrder> LineOrders { get; set; }
    }
}