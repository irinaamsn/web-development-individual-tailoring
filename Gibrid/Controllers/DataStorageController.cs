using Gibrid.Models;
using Gibrid.Models.Interfaces;
using Gibrid.VewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Gibrid.Controllers
{
    public class DataStorageController:Controller
    {
        private readonly IDataStorage _dataStorageRepos;
        private readonly UserManager<User> _userManager;

        public DataStorageController(IDataStorage _dataStorageRepos, UserManager<User> userManager)
        {
            this._dataStorageRepos = _dataStorageRepos;
            _userManager = userManager;
        }
        public async Task<IActionResult> ListDataStorage(string name)
        {
            User user = await _userManager.FindByNameAsync(name);
            var list = _dataStorageRepos.allDataStorages.Where(x=>x.UserId==user.Id).ToList();
            if (list.Count==0) return RedirectToAction("Complete");
            return View(list);
        }
        public IActionResult DeleteData(int id)
        {
            var item = _dataStorageRepos.allDataStorages.SingleOrDefault(x=>x.Id==id);
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
