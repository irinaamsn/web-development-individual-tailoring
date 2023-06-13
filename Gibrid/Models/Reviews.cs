namespace Gibrid.Models
{
    public class Reviews
    {
        public int Id { get; set; }//уникальный идентификатор в БД
        public string? Text { get; set; }//текст под оценкой к отзыву
        public DateTime DateReview { get; set; }//дата создания отзыва
        public int Rating { get; set; }//поставленная оценка
        public bool isDelete { get; set; }//удален ли отзыв
        public string? UserId { get; set; }//ID клиента оставившего отзыв
        public string? UserName { get; set; }//имя клиента
        public User? User { get; set; }
        public int SpecialistId { get; set; }//ID мастера которому ставится отзыв
        public Specialist? Specialist { get; set; }
    }
}
