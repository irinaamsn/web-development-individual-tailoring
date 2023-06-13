using Microsoft.CodeAnalysis;

namespace Gibrid.Models
{
    public class ReseptionItem
    {
        public int Id { get; set; }//уникальный идентификатор в БД
        public int SpecialistId { get; set; }//ID мастера
        public  Specialist? specialist { get; set; }
        public int TimeId { get; set; }//ID времени
        public Time? time { get; set; }
        public string? SpecialistName { get; set; }//имя мастера
        public DateTime Time { get; set; }//время

        public string? ReseptionId { get; set; }
        public string? userId { get; set; }//ID клиента
    }
}
