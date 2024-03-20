using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    public class LineOrder
    {
        public int Id { get; set; }
        [Required]
        [Range(1,Int32.MaxValue, ErrorMessage = "Количество не может быть меньше 1")]
        public int Amount { get; set; }
        [Required]
        public decimal DisplayPrice { get; set; }
        [Required]
        public decimal ShippingPrice { get; set; }

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        [Display(Name = "Поставщик товара")]
        [Required]
        public virtual Product Product { get; set; }

        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        [Display(Name = "Поставщик товара")]
        [Required]
        public virtual Order Order { get; set; }
        public decimal Total => Amount * ShippingPrice;
    }
}