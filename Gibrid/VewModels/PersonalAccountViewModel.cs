using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class PersonalAccountViewModel
    {
        public IEnumerable<Specialist> getAllSpecialist { get; set; }//коллекция всех мастеров
        public IEnumerable<Time> getAllTimes { get; set; }//коллекция всего времени
        //public IEnumerable<SignUpDetail> getAllSignUpDetails { get; set; }
    }
}
