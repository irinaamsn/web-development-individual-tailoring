namespace Gibrid.Models
{
    public class DataStorageItem
    {
        public int Id { get; set; }
        public int SpecialistId { get; set; }
        //public virtual Specialist Specialist { get; set; }
        public string?  CategoryName { get; set; }    
        public string? SpecialistName { get; set; }
        public bool isServiced { get; set; }
        //public bool isRate { get; set; }
        public bool isDelete { get; set; }
        public DateTime Time { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
