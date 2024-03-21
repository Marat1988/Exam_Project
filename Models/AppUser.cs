using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class AppUser: IdentityUser
    {
        [StringLength(20, ErrorMessage = "Имя должно содержать 20 символов")]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [StringLength(15, ErrorMessage = "Фамилия должна содержать 17 символов")]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [StringLength(25, ErrorMessage = "Отчество должно содержать 20 символов")]
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("День рождения")]
        public DateTime? DateBirthDay { get; set; }

        [DisplayName("Аватар")]
        public byte[] Photo {  get; set; }

        [Range(0, 50,ErrorMessage = "Персональная скидка должна быть от 0 до 50")]
        [DisplayName("Персональная скидка")]
        public int? PersonalDiscount { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Recycler> Recyclers { get; set; }
        // Здесь будут указываться дополнительные свойства
    }
}