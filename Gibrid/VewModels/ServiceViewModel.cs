using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class ServiceViewModel
    {
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
