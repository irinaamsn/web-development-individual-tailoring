namespace Gibrid.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public DateTime DateReview { get; set; }
        public int Rating { get; set; }
        public bool isDelete { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public User? User { get; set; }
        public int SpecialistId { get; set; }
        public Specialist? Specialist { get; set; }
    }
}
