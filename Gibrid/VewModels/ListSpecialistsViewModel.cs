using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class ListSpecialistsViewModel
    {
        public IEnumerable<Specialist> Specialists { get; set; }
        public int IsCreate { get; set; }
    }
}
