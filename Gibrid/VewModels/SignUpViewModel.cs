using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class SignViewModel
    {
        public string UserId { get; set; }
        public int SignId { get; set; }
        public string NameUser { get; set; }
        public string PhoneUser { get; set; }
        public DateTime Time { get; set; }
        public bool IsServiced { get; set; }
    }
}
