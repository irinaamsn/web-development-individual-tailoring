namespace Gibrid.Models
{
    public class Works
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public bool isBest { get; set; }
        public bool isDelete { get; set; }
        public int SpecialistId { get; set; }
        public Specialist Specialist { get; set; }
    }
}
