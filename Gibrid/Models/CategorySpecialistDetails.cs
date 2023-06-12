namespace Gibrid.Models
{
    public class CategorySpecialist
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool isEmpty { get; set; }
        public List<Specialist>? SpecialistDetails { get; set; }
    }
}
