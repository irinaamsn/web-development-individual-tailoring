using Gibrid.Models;
using Gibrid.Models.Interfaces;
using Gibrid.VewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gibrid.Controllers
{
    public class DataStorageController:Controller//архив записей пользователя
    {
        private readonly IDataStorage _dataStorageRepos;
        private readonly UserManager<User> _userManager;

        public DataStorageController(IDataStorage _dataStorageRepos, UserManager<User> userManager)
        {
            this._dataStorageRepos = _dataStorageRepos;
            _userManager = userManager;
        }
        public async Task<IActionResult> ListDataStorage(string name)//получение списка записей из архива
        {
            User user = await _userManager.FindByNameAsync(name);//пользователь полученный по имени
            var list = _dataStorageRepos.allDataStorages.Where(x=>x.UserId==user.Id).ToList();//список полученный по айди пользоваетеля
            if (list.Count==0) return RedirectToAction("Complete");
            return View(list);
        }
        public IActionResult DeleteData(int id)//удаление записи(не из БД)
        {
            var item = _dataStorageRepos.allDataStorages.SingleOrDefault(x=>x.Id==id);//сама запись которую хочет удалить пользователь
            _dataStorageRepos.DeleteData(item);
            return RedirectToAction("ListDataStorage", new {name=User.Identity.Name});
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Архив пуст";
            return View();
        }
    }
}
