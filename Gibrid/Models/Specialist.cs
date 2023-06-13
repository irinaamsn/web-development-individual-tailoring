namespace Gibrid.Models
{
    public class Specialist
    {
        public int Id { get; set; }//уникальный идентификатор в БД
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public bool isHasTime { get; set; }//переменная показвает есть ли у мастера время для записи
        public int Experience { get; set; }//стаж мастера
        public int? Rating { get; set; }//рейтинг мастера
        public byte[] Avatar { get; set; }//фото мастера
        public List<Time>? TimeS { get; set; }
        public int CategoryId { get; set; }//ID категории
        public CategorySpecialist? CategorySpecialist { get; set; }
        public string? CategoryName { get; set; }//категоия мастера
        public bool isDelete { get; set; }//удален ли мастер
        public List<Reviews>? listReviewsDetails { get; set; }
        public List<Works>? listWorksDetails { get; set; }
        public string? userId { get; set; }//ID как пользователя 
        public User? User { get; set; }
    }
}

