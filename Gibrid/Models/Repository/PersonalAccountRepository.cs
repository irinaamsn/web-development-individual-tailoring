using Gibrid.Models.Interfaces;

namespace Gibrid.Models.Repository
{
    public class PersonalAccountRepository:IPersonalAccount
    {
        private readonly AppDBContent _content;
        private readonly IDataStorage dataRepos;
        private readonly IListTime timeRepos;
        public PersonalAccountRepository(AppDBContent content, IDataStorage dataRepos, IListTime timeRepos)
        {
            _content = content;
            this.dataRepos = dataRepos;
            this.timeRepos = timeRepos; 
        }
        public void DeleteSignUpByMaster(int idSignUpDet)//SignUp && SignUpDetails
        {
            var signdet = _content.SignUpDetail.SingleOrDefault(x => x.Id == idSignUpDet);
            //var timeDetId = timeRepos.getAllTimeDetails.SingleOrDefault(x => x.Time == signdet.Time && x.SpecialistDetailsId == signdet.SpecialistId).Id;
            //timeRepos.DeleteTime(timeDetId);
            var data = dataRepos.AddToStorage(signdet);
            data.isServiced = true; 
            signdet.isDelete = true;
            signdet.isServiced = true;
            _content.Update(signdet);
            _content.SaveChanges();

        }
        public void DeleteSignUp(int idSignUpDet)//SignUp && SignUpDetails
        {
            var signdet = _content.SignUpDetail.SingleOrDefault(x => x.Id == idSignUpDet);
            //var timeDetId = timeRepos.getAllTimeDetails.SingleOrDefault(x => x.Time == signdet.Time && x.SpecialistDetailsId == signdet.SpecialistId).Id;
            //timeRepos.DeleteTime(timeDetId);
            var data= dataRepos.AddToStorage(signdet);
            
           signdet.isDelete = true;
            _content.Update(signdet);
            _content.SaveChanges();
            
        }
        public void ServicedSignUp(int idSignUpDet)//SignUp && SignUpDetails
        {
            DeleteSignUp(idSignUpDet);
            var sign = _content.SignUpDetail.SingleOrDefault(x => x.Id == idSignUpDet);
            //sign.isServiced = true;
            _content.Update(sign);
            _content.SaveChanges();
        }
        public SignUpDetail mySignUp(string userId) => _content.SignUpDetail.SingleOrDefault(x => x.UserId == userId);
        public SignUpDetail getObjSignUpDetail(int id) => _content.SignUpDetail.SingleOrDefault(x => x.Id == id);
    }
}
