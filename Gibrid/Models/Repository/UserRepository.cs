using Gibrid.Models.Interfaces;

namespace Gibrid.Models.Repository
{
    public class UserRepository:IUser
    {
        private readonly AppDBContent _content;
       // private readonly IUser userResp;
        public UserRepository(AppDBContent content)
        {
            _content = content;
        }
        public IEnumerable<User> Users=>_content.Users;
        //public void createUser(User user)
        //{
        //    //_content.User.Add(
        //    //new User()
        //    //{
        //    //    Name = user.Name,
        //    //    surName=user.surName,
        //    //    fullName=user.fullName,
        //    //    phone=user.phone,
        //    //    email=user.email,
        //    //    password=user.password
        //    //});
            
        //    //_content.SaveChanges();
        //}
    }
}
