using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using System.ComponentModel;

namespace Store.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Дата создания заявки")]
        public DateTime DateTimeCreate { get; set; }
        [DisplayName("Пользователь")]
        public string UserId { get; set; }
        [Required]
        [ForeignKey("UserId")]
        [Display(Name = "Пользователь")]
        public virtual AppUser User { get; set; }
        public virtual ICollection<LineOrder> LineOrders { get; set; }
    }
}