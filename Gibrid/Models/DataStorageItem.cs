namespace Gibrid.Models
{
    public class DataStorageItem
    {
        public int Id { get; set; }//уникальный идентификатор в БД
        public int SpecialistId { get; set; }//ID мастера
        public string?  CategoryName { get; set; } // название категории
        public string? SpecialistName { get; set; }//имя мастера
        public bool isServiced { get; set; }//обслужена ли запись
        public bool isDelete { get; set; }//удалена ли запись (из архива записей клиентом)
        public DateTime Time { get; set; }//время записи
        public string UserId { get; set; }//ID клиента
        public virtual User User { get; set; }
    }
}
