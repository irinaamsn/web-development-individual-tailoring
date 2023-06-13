 using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Gibrid.Models
{
    public class SignUpDetail
    {
        public int Id { get; set; }//уникальный идентификатор в БД
        public int SpecialistId { get; set; }//ID мастера к которому идет запись
        public virtual Specialist specialist { get; set; }
        public string SpecialistName { get; set; }//имя мастера
        public bool isDelete { get; set; }//показывает удалена ли запись
        public bool isServiced { get; set; }//показывает обслужана ли запись
        public int TimeSignId { get; set; }//ID выбранного времни клиентом
        public DateTime Time { get; set; }//время записи
        public int SignUpId { get; set; }//ID записи, формы куда пользователь вводит свои данные при записи
        public SignUp? SignUp { get; set; }//his data
        public string UserId { get; set; }//ID клиента
        public virtual User User { get; set; }

    }
}
