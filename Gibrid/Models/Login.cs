using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gibrid.Models
{
    public class Login
    {
        [Required]//атрибут указывает что это поле обязательно для заполнения и для проверки на валидность
        [Display(Name = "Email")]//атрибут определяет отображаемое имя для свойства 
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]//атрибут указывает на то, что поле предназначено для ввода пароля
        [Display(Name = "Пароль")]
        public string? Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
