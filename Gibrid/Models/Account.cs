using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Xml.Linq;

namespace Gibrid.Models
{
    public class Account
    {
        [Required]//атрибут указывает что это поле обязательно для заполнения и для проверки на валидность
        [Display(Name = "Email")]//атрибут определяет отображаемое имя для свойства 
        public string Email { get; set; }

        [Required]
        [Display(Name = "Year")]
        public int Year { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]//атрибут сравнивает значение свойства PasswordConfirm со свойством Password
        [DataType(DataType.Password)]//атрибут указывает на то, что поле PasswordConfirm предназначено для ввода пароля
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}
