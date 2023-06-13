using Gibrid.Models.Interfaces;
using Gibrid.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Gibrid.VewModels;

namespace Gibrid.Controllers
{
    public class PersonalAccountController:Controller//личный кабинет пользователя
    {
        private readonly UserManager<User> _userManager;
        private readonly IPersonalAccount personalAccountPepos;
        private readonly IListTime listTimeRepos;
        private readonly IAllSpecialist spRepos;
        private readonly IAllSignUp SignUpRepos;
        private readonly IDataStorage dataRepos;
        private readonly IReview reviewRepos;
       
        private readonly Reseption reseption;
        public PersonalAccountController(UserManager<User> userManager,  IPersonalAccount personalAccountPepos, IListTime listTimeRepos, IAllSpecialist spRepos, IAllSignUp allSignUp, IDataStorage dataRepos, IReview reviewRepos, Reseption reseption)
        {          
            _userManager = userManager;
            this.personalAccountPepos = personalAccountPepos;
            this.listTimeRepos = listTimeRepos;
            this.spRepos = spRepos;
            SignUpRepos = allSignUp;
            this.dataRepos = dataRepos;
            this.reviewRepos = reviewRepos;
          
            this.reseption = reseption;
        }

        public IActionResult CreateSignUp(int idSp)//Id мастера
         {
            var list = reseption.getReseptionItem();//текущая корзина (мастер и время)
            var specialist = spRepos.getObjectSpecialist(idSp);//специалистполученный по ID
            var times = listTimeRepos.getAllTimeDetails.Where(x => x.SpecialistDetailsId == specialist.Id && !x.isDelete);//время доступное для записи у мастера
            if (times.Count() == 0) specialist.isHasTime = false;//если времени нет то у спеуиалиста стоит false
            var listTime = listTimeRepos.getAllTimeDetails.Where(x => x.SpecialistDetailsId == idSp);//список времени мастера по его айди 
            SignUpDetail sign = null;
            ReseptionItem newLst = null;
            CreateSignUpViewModel model = null;
            if (list==null)
            {
                var user = User.Identity.Name;
                var userId = _userManager.FindByNameAsync(user).Result.Id;//id авторизованного пользователя - мастера
                sign = SignUpRepos.AllSignUpDetails.SingleOrDefault(x => x.UserId == userId && !x.isDelete && !x.isServiced);// запись к мастеру
                if (sign !=null) newLst = new ReseptionItem { Time = sign.Time };
                model = new CreateSignUpViewModel { Specialist = specialist, allTimeSpecialist = listTime, ReseptionItems = newLst };
            }
            else model = new CreateSignUpViewModel { Specialist = specialist, allTimeSpecialist = listTime, ReseptionItems = list };
            return View(model);
        }
        //public IActionResult DropdownAlerts()
        //{
        //    return View("MyAlerts",User.Identity.Name);
        //}

        public IActionResult RateMaster()
        {     
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RateMaster(ReviewViewModel reviews, int id, int storId ,int Rating)//метод создания отзыва
        {
            var specialist = spRepos.getObjectSpecialist(id);//специалист найденный по айди
            spRepos.ChangeRating(specialist, Rating);//изменем его рейтинг после оценки
            var clientName = User.Identity.Name;//имя авторизованного пользователя- клиента
           
            User user = await _userManager.FindByNameAsync(clientName);//авторизованный пользователь найденный по имени
            //var clientId = user.Id;//его айди
            //var storage = dataRepos.allDataStorages.SingleOrDefault(x => x.Id == storId);
            //storage.isRate = true;
            if (ModelState.IsValid)
            {
                reviewRepos.createReview(reviews, user, id, Rating);//прр валидном заполнении данных пользователем создается отзыв и добавляется в БД
                
            }
            Thread.Sleep(1000);//остановка на 1 секунду
            return RedirectToAction("Signs", new { name = clientName });//перенаправление пользователя в свой ЛК
        }
        public async Task<IActionResult> Settings(string name)//метод изменения ПД пользователя
        {
            User user = await _userManager.FindByNameAsync(name);//сам авторизованный пользователь
            if (user == null)
            {
                return NotFound();
            }
            SettingsViewModel model = new SettingsViewModel { UserName = user.UserName, Email = user.Email, Year = user.Year, OldPassword = user.Password };
            //создание класса содержащего персональные данные 
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Settings(SettingsViewModel model)//получение новых данных измененных пользователем
        {
            if (ModelState.IsValid)//при валидном изменении данных
            {
                User user = await _userManager.FindByNameAsync(model.UserName);//пользователь
                if (user != null)
                {                  //переопределние его данных
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.Year = model.Year;
                    user.Password = model.NewPassword;

                    var result = await _userManager.UpdateAsync(user);//сохранение
                    if (result.Succeeded)
                    {
                        return View(model);
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }           
            return View(model);
        }

        public IActionResult Signs(string name)//ЛК пользователя содержащий текущую запись и архив записей
        {
            UserViewModel model = null;
            var id = _userManager.FindByNameAsync(name).Result.Id;//айди пользователя
            var sign = SignUpRepos.AllSignUpDetails.SingleOrDefault(x => x.UserId == id && !x.isDelete);//его запись 

            if (sign != null)//если запись текущая есть
            {
                var time = listTimeRepos.getObjectTimeDetail(sign.TimeSignId);//получение времени записи
                model = new UserViewModel//модель содержащая информацию о записи для вывода в представлении (странице)
                {
                    Sign = sign,
                    Time = time,
                    Specialist = spRepos.Specialists.SingleOrDefault(x => x.Id == sign.SpecialistId),
                    OldSigns = dataRepos.allDataStorages.Where(x => x.UserId == id).ToList()//его архив записей

                };
            }
            else
            {
                var oldSigns = dataRepos.allDataStorages.Where(x => x.UserId == id).ToList();
                model = new UserViewModel
                {
                    Sign = sign,

                    OldSigns = dataRepos.allDataStorages.Where(x => x.UserId == id).ToList()

                };
            }
            //var obj = personalAccountPepos.mySignUp(id);
            return View(model);
        }


        public ViewResult SpecialistList()
        {
            var allspecialists = spRepos.Specialists;
            var times = listTimeRepos.getAllTimeDetails;
            var list = new PersonalAccountViewModel
            {
                getAllSpecialist=allspecialists,
                getAllTimes=times
            };

            return View(list);
        }
        public IActionResult CancelSignUp(int signId)//метод отмены записей пользователя
        {
            var sign = SignUpRepos.AllSignUpDetails.SingleOrDefault(x=>x.Id==signId);//его текущая запись
            var timeId = sign.TimeSignId;
            var specialist = spRepos.Specialists.SingleOrDefault(x => x.Id == sign.SpecialistId); //специалист к которому он записан находится по айди
            specialist.isHasTime = true;
            listTimeRepos.ReturnTime(timeId);//возвращение времени в список предложенных когда пользователь будет записываться  кэтому мастеру
            personalAccountPepos.DeleteSignUp(signId);//удаление записи (из БД не удаляется)
            return RedirectToAction("Signs", "PersonalAccount", new {name=User.Identity.Name});//перенаправление на ЛК поользователя
        }
        public IActionResult Complete()
        {
            ViewBag.Message = "Запись отменена";
            return View();
        }
    }
}
