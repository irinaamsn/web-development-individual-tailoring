using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class SettingsViewModel
    {
        public string UserName { get; set; }//имя пользователя
        public string Email { get; set; }//почта
        public int Year { get; set; }//год рождения
        public string NewPassword { get; set; }//новый пароль
        public string OldPassword { get; set; }//старый пароль
    }
}
