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
        public void DeleteSignUpByMaster(int idSignUpDet)//удаление записи в случае обслуживания
        {
            var signdet = _content.SignUpDetail.SingleOrDefault(x => x.Id == idSignUpDet);
            var data = dataRepos.AddToStorage(signdet);//добавление записи в архив записей
            data.isServiced = true;//установка статуса обслуживания
            var time = timeRepos.getAllTimeDetails.SingleOrDefault(x => x.Id == signdet.TimeSignId);//получение времени по его айди
            time.isDelete = true;//установка статуса удаления
            signdet.isDelete = true;//установка статуса удаления
            signdet.isServiced = true;//установка статуса обслуживания
            _content.Update(signdet);//обновление записи в БД
            _content.SaveChanges();//сохранение изменений в БД

        }
        public void DeleteSignUp(int idSignUpDet)//удаление записи
        {
            var signdet = _content.SignUpDetail.SingleOrDefault(x => x.Id == idSignUpDet);//получение записи по его айди
            var data= dataRepos.AddToStorage(signdet); //добавление записи в архив записей       
            signdet.isDelete = true;//установка статуса удаления
            _content.Update(signdet);//обновление записи в БД
            _content.SaveChanges();//сохранение изменений в БД

        }
        public void ServicedSignUp(int idSignUpDet)//SignUp && SignUpDetails
        {
            DeleteSignUp(idSignUpDet);//удаление записи
            var sign = _content.SignUpDetail.SingleOrDefault(x => x.Id == idSignUpDet);//получение записи по его айди
            _content.Update(sign);//обновление записи в БД
            _content.SaveChanges();//сохранение изменений в БД
        }
        public SignUpDetail mySignUp(string userId) => _content.SignUpDetail.SingleOrDefault(x => x.UserId == userId);//получение записи по айди клиента из БД
        public SignUpDetail getObjSignUpDetail(int id) => _content.SignUpDetail.SingleOrDefault(x => x.Id == id);
    }
}
