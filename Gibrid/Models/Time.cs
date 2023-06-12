namespace Gibrid.Models
{
    public class Time
    {
        public int Id { get; set; }
        public bool isActive { get; set; }//млжно ли взять это время //false - нельзя
        public bool isDelete { get; set; }
        public DateTime TimeSpecialist { get; set; }
        public int SpecialistDetailsId { get; set; }
        public Specialist SpecialistDetails { get; set; }
    }
}
