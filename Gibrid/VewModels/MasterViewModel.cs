using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class MasterViewModel
    {
        public IEnumerable<SignUpDetail> signUps { get; set; }
        public IEnumerable<Works> worksDetails { get; set; }
        public IEnumerable<Reviews> reviewsDetails { get; set; }

    }
}
