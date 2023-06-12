using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Gibrid.Models
{
    public class SignUp
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name = "Введите имя")]
        // [StringLength(20)]
        [Required(ErrorMessage = "Длина имени не более 10 символов")]
        public string? Name { get; set; }
        //[Required]
        [Display(Name = "Введите номер телефона")]
        // [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера телефона не совпадает")]
        public string? phone { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime signTime { get; set; }
    }
}
