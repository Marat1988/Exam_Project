using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Store.Models
{
    public class Group
    {
        public int Id { get; set; }
        [StringLength(50, ErrorMessage = "Название должно содержать 50 символов")]
        [Index("UQ_GroupName",IsUnique = true)]
        [Required]
        [Display(Name = "Наименование группы")]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}