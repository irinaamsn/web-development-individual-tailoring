namespace Gibrid.Models
{
    public class Time
    {
        public int Id { get; set; }//уникальный идентификатор в БД
        public bool isActive { get; set; }//переменная определяющая можно ли взять этов время //false - нельзя
        public bool isDelete { get; set; }//булевская переменная для проверки на то удалено ли это время
        public DateTime TimeSpecialist { get; set; }//время мастера
        public int SpecialistDetailsId { get; set; }//ID мастера
        public Specialist SpecialistDetails { get; set; }//мастер
    }
}
