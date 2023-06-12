namespace Gibrid.Models
{
    public class Specialist
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public bool isHasTime { get; set; }
        public int Experience { get; set; }
        public int? Rating { get; set; }
        public byte[] Avatar { get; set; }
        public List<Time>? TimeS { get; set; }//??????????
        public int CategoryId { get; set; }
        public CategorySpecialist? CategorySpecialist { get; set; }
        public string? CategoryName { get; set; }
        public bool isDelete { get; set; }
        public List<Reviews>? listReviewsDetails { get; set; }
        public List<Works>? listWorksDetails { get; set; }
        public string? userId { get; set; }
        public User? User { get; set; }

        //public DateTime Time { get; set; }
        //public List<DateTime> Times { get; set; }
    }
}

