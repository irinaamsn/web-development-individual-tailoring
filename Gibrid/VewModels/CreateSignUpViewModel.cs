using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class CreateSignUpViewModel
    {
        public SignUp SignUp { get; set; }
        public ReseptionItem ReseptionItems { get; set; }
        public Specialist Specialist { get; set; }
        public int TimeId { get; set; }
        public IEnumerable<Time> allTimeSpecialist { get; set; }
    }
}
