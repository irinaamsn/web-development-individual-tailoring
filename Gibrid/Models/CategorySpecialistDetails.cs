namespace Gibrid.Models
{
    public class CategorySpecialist
    {
        public int Id { get; set; }//уникальный идентификатор в БД
        public string? Name { get; set; }//название категории
        public bool isEmpty { get; set; }
        public List<Specialist>? SpecialistDetails { get; set; }
    }
}
