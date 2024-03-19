using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Store.Models
{
    public class Recycler
    {
        public int Id { get; set; }
        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Количество не может быть меньше 1")]
        public int Amount { get; set; }
        [Required]
        public decimal DisplayPrice { get; set; }
        [Required]
        public decimal ShippingPrice { get; set; }
        [Required]
        public int ProductId { get; set; }

        [DisplayName("Пользователь")]
        public string UserId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        [Display(Name = "Пользователь")]
        public virtual AppUser User { get; set; }

        public decimal Total => Amount * ShippingPrice;

    }
}