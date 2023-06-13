using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class SignViewModel
    {
        public string UserId { get; set; }//уникальный идентификатор пользователя
        public int SignId { get; set; }//ID записи в БД
        public string NameUser { get; set; }//имя пользователя из записи
        public string PhoneUser { get; set; }//номер телефона пользователя из записи
        public DateTime Time { get; set; }//время в записи
        public bool IsServiced { get; set; }//обслужена ли запись
    }
}
