using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class AdminViewModel
    {
        public IEnumerable<SignUpDetail> signUpDetails=new List<SignUpDetail>();//коллекция записей
        public IEnumerable<SignUp> signUp = new List<SignUp>();//коллекция записей (форма заполнения клиента дополнительной о нем информации при записи)
    }
}
