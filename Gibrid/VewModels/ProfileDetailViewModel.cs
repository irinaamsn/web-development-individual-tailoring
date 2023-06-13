using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class ProfileDetailViewModel
    {
        public Specialist Specialist { get; set; }//мастер
        public IEnumerable<Reviews> allReviews { get; set; }//коллекция отзывов мастера
        public IEnumerable<Works> allWorks { get; set; }//коллекция работ мастера
    }
}
