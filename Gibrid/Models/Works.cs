namespace Gibrid.Models
{
    public class Works
    {
        public int Id { get; set; }//уникальный идентификатор в БД
        public byte[] Image { get; set; }//массив байтов для хранения фото
        public bool isBest { get; set; }//является ли эта работой лучшей у мастера
        public bool isDelete { get; set; }//удалена ли эта работа
        public int SpecialistId { get; set; }//ID мастера
        public Specialist Specialist { get; set; }
    }
}
