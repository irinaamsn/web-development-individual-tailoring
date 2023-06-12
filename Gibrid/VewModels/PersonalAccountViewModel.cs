using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class PersonalAccountViewModel
    {
        public IEnumerable<Specialist> getAllSpecialist { get; set; }
        public IEnumerable<Time> getAllTimes { get; set; }
        //public IEnumerable<SignUpDetail> getAllSignUpDetails { get; set; }
    }
}
