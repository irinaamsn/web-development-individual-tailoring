using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class AdminViewModel
    {
        public IEnumerable<SignUpDetail> signUpDetails=new List<SignUpDetail>();
        public IEnumerable<SignUp> signUp = new List<SignUp>();
    }
}
