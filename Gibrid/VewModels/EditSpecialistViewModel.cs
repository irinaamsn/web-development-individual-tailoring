using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class EditSpecialistViewModel
    {
        public int SpecialistId { get; set; }//ID Мастера
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public int Experience { get; set; }//стаж мастера
        public string CategoryName { get; set; }//категория мастера
    }
}
