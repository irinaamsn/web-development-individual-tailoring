using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class EditSpecialistViewModel
    {
        public int SpecialistId { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public int Experience { get; set; }
        public string CategoryName { get; set; }
    }
}
