using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Gibrid.Models
{
    public class SignUp
    {
        [BindNever]// значение свойства Id не будет автоматически заполняться из данных запроса при обработке запроса на сервере
        public int Id { get; set; }//уникальный идентификатор 
        [Display(Name = "Введите имя")]//атрибут определяет отображаемое имя для свойства 
        // [StringLength(20)]
        [Required(ErrorMessage = "Длина имени не более 10 символов")]//атрибут указывает что это поле обязательно для заполнения и для проверки на валидность
        public string? Name { get; set; }
        //[Required]
        [Display(Name = "Введите номер телефона")]
        // [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера телефона не совпадает")]
        public string? phone { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]// атрибут показывает что свойство signTime не должно участвовать в процессе генерации пользовательского интерфейса 
        public DateTime signTime { get; set; }
    }
}
