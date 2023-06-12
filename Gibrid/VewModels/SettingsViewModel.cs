using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class SettingsViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public int Year { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}
