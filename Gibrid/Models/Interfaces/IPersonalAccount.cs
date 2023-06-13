namespace Gibrid.Models.Interfaces
{
    public interface IPersonalAccount
    {
        public SignUpDetail mySignUp(string userId);//получение записи для страницы с ЛК
        public SignUpDetail getObjSignUpDetail(int id);//получение записи по айди
        public void DeleteSignUp(int idSignUpDet);//удаление записи (в случае отмены)
        public void DeleteSignUpByMaster(int idSignUpDet);//удаление записи мастером (в случае обслуживания)
        public void ServicedSignUp(int idSignUpDet);//отмена записи клиентом
    }
}
