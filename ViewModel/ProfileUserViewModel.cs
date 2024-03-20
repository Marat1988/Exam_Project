using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Store.ViewModel
{
    public class ProfileUserViewModel
    {
        public string Id { get; set; }

        [StringLength(20, ErrorMessage = "Имя должно содержать не более 20 символов")]
        [DisplayName("Имя")]
        public string FirstName { get; set; }

        [StringLength(15, ErrorMessage = "Фамилия должна содержать 17 символов")]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [StringLength(25, ErrorMessage = "Отчество должно содержать 20 символов")]
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("День рождения")]
        public DateTime? DateBirthDay { get; set; }
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [DisplayName("Аватар")]
        public byte[] Photo { get; set; }

    }
}