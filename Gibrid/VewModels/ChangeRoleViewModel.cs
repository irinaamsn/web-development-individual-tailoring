using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class ChangeRoleViewModel
{
    public string UserId { get; set; }//уникальный идентификатор пользователя
    public string UserEmail { get; set; }//почта пользователя
    public List<IdentityRole> AllRoles { get; set; }//список ролей
    public IList<string> UserRoles { get; set; }
    public ChangeRoleViewModel()//модель содержащуая данная для изменения роль пользователя
    {
        AllRoles = new List<IdentityRole>();
        UserRoles = new List<string>();
    }
}