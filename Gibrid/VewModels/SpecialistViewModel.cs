using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class SpecialistViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public int Experience { get; set; }
        public IFormFile? Avatar { get; set; }
        public string? Category { get; set; }
        public string? UserName { get; set; }
        
    }
}
