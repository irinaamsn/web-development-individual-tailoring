using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class MasterViewModel
    {
        public IEnumerable<SignUpDetail> signUps { get; set; }//коллекция записей к мастеру
        public IEnumerable<Works> worksDetails { get; set; }//коллекция работ мастера
        public IEnumerable<Reviews> reviewsDetails { get; set; }//коллекция отзывов мастера

    }
}
