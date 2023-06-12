using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using Gibrid.Models;
using Gibrid.Models.Interfaces;
using Gibrid.Models.Repository;
using Gibrid.VewModels;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.AspNetCore.Identity;
using Azure.Messaging;
using BootstrapBlazor.Components;

namespace Gibrid.Controllers
{
    public class ReseptionController:Controller
    {
        private readonly IAllSpecialist spRepository;
        private readonly IListTime timeRepository;
        private readonly Reseption reseption;
        private readonly IAllSignUp allSignUp;
        private readonly UserManager<User>_userManager;
        public ReseptionController(IAllSpecialist spRepository, Reseption reseption,IListTime listTime,IAllSignUp allSignUp, UserManager<User> userManager)
        {
            this.spRepository = spRepository;
            this.reseption = reseption;
            timeRepository = listTime;
            this.allSignUp = allSignUp;
            _userManager=userManager;
        }   
        public ViewResult Index()
        {
            var items = reseption.getReseptionItem();
            reseption.ReseptionItem = items;
            var obj = new ReseptionViewModel()
            {
                Reseption = reseption
            };

            return View(obj);
        }

        public IActionResult AddToReseption(int timeId, int id)
        {
            var user = User.Identity.Name;
            var idUser = _userManager.FindByNameAsync(user).Result.Id;
            var item = spRepository.Specialists.FirstOrDefault(c => c.Id == id);
            var anySign = allSignUp.AllSignUpDetails.SingleOrDefault(x => x.UserId == idUser && !x.isDelete);
            if (anySign == null)
            //if (allSignUp.AllSignUpDetails.Any(x => x.UserId == idUser)) return RedirectToAction("Complete");
            {

                DateTime time = timeRepository.getObjectTimeDetail(timeId).TimeSpecialist;
                ReseptionItem reseptionItem = null;
                if (item != null)
                {
                    reseptionItem = reseption.AddToReseption(item, time, idUser, timeId);
                    //reseption.DeleteTime(timeId);//todo
                }

                return RedirectToAction("CreateSignUp", "PersonalAccount", new { idSp = item.Id });
            }
            
                //Message messageContent = new Message();
                //messageContent.Type = 
                return RedirectToAction("Complete");
            
          // return RedirectToAction("CreateSignUp", "PersonalAccount",  new { idSp = item.Id, items=reseptionItem});    
        }
        public IActionResult DeleteFromReseption(int id)
        {
            reseption.DeleteFromReseption(id);

            return RedirectToAction("Index","PersonalAccount");
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Вы уже записаны";
            return View();
        }

    }
}
