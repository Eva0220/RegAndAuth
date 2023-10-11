using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformBez.Data.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        [RegularExpression(@"^[1-9]{4}$" , ErrorMessage = "Неверный формат! Логин должен содержать 4 цифры.")]
        public string Login { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]{6}$", ErrorMessage = "Неверный формат! Пароль должен содержать 6 символов: буквы и цифры.")]
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
