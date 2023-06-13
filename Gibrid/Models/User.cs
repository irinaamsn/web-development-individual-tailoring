using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Gibrid.Models
{
    public class User:IdentityUser
    {
    [BindNever]//атрибут указывает что свойство не должно участвовать в процессе привязки модели в контроллере
        public override string? Id { get; set; }//уникальный идентификатор
        [Required]
        public int Year { get; set; }
    [Required]
        public override string? Email { get; set; }
    [Required]
        public string? Password { get; set; }

    }
}
