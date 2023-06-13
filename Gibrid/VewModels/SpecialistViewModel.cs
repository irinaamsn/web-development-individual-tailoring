using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class SpecialistViewModel
    {
        public int Id { get; set; }//ID мастера в БД
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public int Experience { get; set; }//стаж
        public IFormFile? Avatar { get; set; }//фото мастера
        public string? Category { get; set; }//категория мастера
        public string? UserName { get; set; }//имя пользователя
        
    }
}
