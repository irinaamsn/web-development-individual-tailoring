namespace Gibrid.VewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }//уникальный идентификатор пользователя
        public string Email { get; set; }//почта пользователя
        public string NewPassword { get; set; }//новый пароль
        public string OldPassword { get; set; }//старый пароль
    }
}
