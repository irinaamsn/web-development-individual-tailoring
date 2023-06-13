using Gibrid.Models;
using Gibrid.Models.Interfaces;
using Gibrid.VewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using static System.Net.WebRequestMethods;

namespace Gibrid.Controllers
{
    public class AdminController:Controller
    {
        private readonly IAllSignUp SignUpRepos;
        private readonly IAllSpecialist specialistRepos;
        private readonly ISpecialistCategory categoryRepos;
        private readonly IListTime timeRepos;
        private readonly IPersonalAccount personRepos;
        private readonly IAllWorks workRepos;
    
        public AdminController(IAllSignUp sign, IAllSpecialist spRepos, IListTime timeRepos,IPersonalAccount personalAccount, IAllWorks workRepos, ISpecialistCategory categoryRepos)
        {
            SignUpRepos = sign;
            specialistRepos = spRepos;
            this.timeRepos = timeRepos;
            personRepos = personalAccount;
            this.workRepos = workRepos;
            this.categoryRepos = categoryRepos;
          
        }

        public IActionResult List()//получение списка записей
        {
            var listsignUpDetails = SignUpRepos.AllSignUpDetails.OrderBy(x => x.Id).ToList();
            var listsignUp = SignUpRepos.AllSignUp.OrderBy(x => x.Id).ToList();
            //IEnumerable<Order> listOrder = allOrder.AllOrders.ToList();
            var adminObj = new AdminViewModel()
            {
                signUp=listsignUp,
                signUpDetails=listsignUpDetails,
            };

            return View(adminObj);
        }
        public IActionResult AddSpecialist()//will some actions on view - click on button
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSpecialist(SpecialistViewModel specialist)//добавление специалиста администратором
        {
            if (ModelState.IsValid)
            {
                specialistRepos.createSpecialist(specialist);// создание мастера и добавление в БД
                return RedirectToAction("Complete");
            }
            return View(specialist);
        }
        public IActionResult AddCategory()//will some actions on view - click on button
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(CategorySpecialistViewModel category)//метод позволяющий содавать категории мастеров
        {
            if (ModelState.IsValid)
            {
                categoryRepos.createCategory(category);//создание категории и добавление в БД
                return RedirectToAction("CompleteCategory");
            }
            return View(category);
        }
        public IActionResult AddTime()//will some actions on view - click on button
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTime(TimeViewModel model, int id)//метод добавления времени мастеру
        {
            if (timeRepos.getAllTimeDetails.Any(x=>x.TimeSpecialist==model.Time)) return RedirectToAction("CompleteNotTime");

           // if (ModelState.IsValid)
            {
                timeRepos.createTime(model,id);//создание времени и добавление в БД
                return RedirectToAction("Complete2");
            }
            return View(model);
        }
       
        public IActionResult Complete()
        {
            ViewBag.Message = "Специалист добавлен";
            return View();
        }
        public IActionResult Complete2()
        {
            ViewBag.Message = "Время добавлено";
            return View();
        }
        public IActionResult CompleteNotTime()
        {
            ViewBag.Message = "Введенное время уже существует у данного специалиста!";
            return View();
        }
        public IActionResult CompleteCategory()
        {
            ViewBag.Message = "Категория добавлена";
            return View();
        }
        public IActionResult CompleteWork()
        {
            ViewBag.Message = "Работа добавлена";
            return View();
        }
    }
}
