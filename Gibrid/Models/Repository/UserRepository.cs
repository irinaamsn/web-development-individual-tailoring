using Gibrid.Models.Interfaces;

namespace Gibrid.Models.Repository
{
    public class UserRepository:IUser
    {
        private readonly AppDBContent _content;
        public UserRepository(AppDBContent content)
        {
            _content = content;
        }
        public IEnumerable<User> Users=>_content.Users;//получение всех пользователей из БД
    }
}
