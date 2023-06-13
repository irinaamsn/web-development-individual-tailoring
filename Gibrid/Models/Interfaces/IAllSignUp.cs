namespace Gibrid.Models.Interfaces
{
    public interface IAllSignUp
    {
        void createSignUp(SignUp sign, string userId, int idTime);//метод создания записи
        public IEnumerable<SignUpDetail> AllSignUpDetails { get; }//получение всех записей
        public IEnumerable<SignUp> AllSignUp { get; }//получение записи (введенные данные пользователем)
        //public SignUpDetail mySignUp(string userId);
        public SignUpDetail getObjSignUpDetail(int id);//получение записи по айди
        public SignUp getObjSignUp(int id);//
    }
}
