using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class ProfileDetailViewModel
    {
        public Specialist Specialist { get; set; }
        public IEnumerable<Reviews> allReviews { get; set; }
        public IEnumerable<Works> allWorks { get; set; }
    }
}
