namespace Gibrid.Models.Interfaces
{
    public interface IPersonalAccount
    {
        public SignUpDetail mySignUp(string userId);
        public SignUpDetail getObjSignUpDetail(int id);
        public void DeleteSignUp(int idSignUpDet);
        public void DeleteSignUpByMaster(int idSignUpDet);
        public void ServicedSignUp(int idSignUpDet);
    }
}
