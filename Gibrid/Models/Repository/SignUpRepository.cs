using Gibrid.Models.Interfaces;

namespace Gibrid.Models.Repository
{
    public class SignUpRepository:IAllSignUp
    {
        private readonly AppDBContent _content;
        private readonly Reseption reseption;
        private readonly IListTime timeRepos;
        public SignUpRepository(AppDBContent content, Reseption reseption, IListTime timeRepos)
        {
            _content = content;
            this.reseption = reseption;
            this.timeRepos = timeRepos;
        }
        public void createSignUp(SignUp sign,string userId, int idTime)
        {
            sign.signTime = DateTime.Now;
            _content.SignUp.Add(sign);//добавлние записи в соответствующую таблицу в БД
            _content.SaveChanges();//сохранение изменений в БД
            var item = reseption.ReseptionItem;
          //  foreach (var item in items)
            {
                var signDetail = new SignUpDetail()
                {
                    SpecialistId = item.SpecialistId,
                    specialist=item.specialist,
                    SpecialistName=item.SpecialistName,
                    SignUpId = sign.Id,
                    TimeSignId=idTime,
                    isServiced=false,
                    Time = item.Time,
                    UserId=userId
                };
                _content.SignUpDetail.Add(signDetail);
            }
            var reseptionItem = _content.ReseptionItem.SingleOrDefault(x => x.ReseptionId == reseption.ReseptionId);
            _content.ReseptionItem.Remove(reseptionItem);
            _content.SaveChanges();//сохранение изменений в БД
        }
        public IEnumerable<SignUpDetail> AllSignUpDetails => _content.SignUpDetail;//получение всех записей из БД
        public IEnumerable<SignUp> AllSignUp => _content.SignUp;//получение всех записей (данных введеных клиентом) из БД
        public SignUpDetail getObjSignUpDetail(int id) => _content.SignUpDetail.SingleOrDefault(x=>x.SignUpId==id);//получение записи по ID из БД
        public SignUp getObjSignUp(int id) => _content.SignUp.SingleOrDefault(x => x.Id == id);
    }
}
