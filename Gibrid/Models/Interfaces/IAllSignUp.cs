namespace Gibrid.Models.Interfaces
{
    public interface IAllSignUp
    {
        void createSignUp(SignUp sign, string userId, int idTime);
        public IEnumerable<SignUpDetail> AllSignUpDetails { get; }
        public IEnumerable<SignUp> AllSignUp { get; }
        //public SignUpDetail mySignUp(string userId);
        public SignUpDetail getObjSignUpDetail(int id);
        public SignUp getObjSignUp(int id);
    }
}
