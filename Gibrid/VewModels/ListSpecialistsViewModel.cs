using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class ListSpecialistsViewModel
    {
        public IEnumerable<Specialist> Specialists { get; set; }//коллекция мастеров
        public int IsCreate { get; set; }//можно ли к ним записаться
    }
}
