using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class UserViewModel
    {
        public SignUpDetail Sign { get; set; }
        public Time Time { get; set; }
        public Specialist Specialist { get; set; }
        public List<DataStorageItem> OldSigns { get; set; }
    }
}
