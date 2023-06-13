using Gibrid.Models.Interfaces;
using Gibrid.Models;
using Gibrid.VewModels;
using Microsoft.AspNetCore.Mvc;
using Gibrid.Models.Repository;
using Microsoft.AspNetCore.Identity;
using NuGet.Protocol.Core.Types;

namespace Gibrid.Controllers
{
    public class SpecialistController : Controller
    {
        private readonly IAllSpecialist _allSpecialist;
        private readonly IAllSignUp _signRepos;
        private readonly IAllWorks _workRepos;
        private readonly IReview _reviewRepos;
        private readonly UserManager<User> _userManager;
        public SpecialistController(IAllSpecialist allSpecialist, IAllSignUp signRepos, IAllWorks workRepos, UserManager<User> userManager, IReview reviewRepos)
        {
            _allSpecialist = allSpecialist;
            _signRepos = signRepos;
            _workRepos = workRepos;
            _userManager = userManager;
            _reviewRepos = reviewRepos;
        }
        [Route("Specialist/List")]
        [Route("Specialist/List/{category}")]
        public ViewResult List(string category)// список специалистов 
        {
            int isCreate = 0;
            var user = User.Identity.Name;
            var idUser = _userManager.FindByNameAsync(user).Result.Id;
            var anySign = _signRepos.AllSignUpDetails.SingleOrDefault(x => x.UserId == idUser && !x.isDelete);
            if (anySign != null) isCreate = 1;
                string _category = category;
            IEnumerable<Specialist> specialists = null;
            var list = new ListSpecialistsViewModel();
            string currcategory = "";
            if (string.IsNullOrEmpty(category))//получение всех мастеров
            {
                specialists = _allSpecialist.Specialists.OrderBy(i => i.Id);
                 list = new ListSpecialistsViewModel()
                {
                    Specialists = specialists,
                    IsCreate = isCreate
                };
            }
            else//получение мастеров определеннной категории
            {
                specialists = _allSpecialist.Specialists.Where(x => x.CategoryName == category);
                list = new ListSpecialistsViewModel()
                {
                    Specialists = specialists,
                    IsCreate = isCreate
                };
            }
            return View(list);
        }
        public ViewResult ProfileDetail(int idSp)//страница отображаемая более подробную информацию о мастере
        {
            var specialist = _allSpecialist.Specialists.SingleOrDefault(x => x.Id == idSp);//сам мастер
            var works  = _workRepos.WorksDetails.Where(x=>x.SpecialistId==idSp);//его работы
            var reviews = _reviewRepos.allReviewsDetails.Where(x=>x.SpecialistId== idSp); //его отзывы  
            var model = new ProfileDetailViewModel//модель для представления содержащиая все нужные данные
            {
                Specialist=specialist,
                allWorks=works,
                allReviews=reviews
            };
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)//редактирование ПД мастера
        {
            //User user = await _userManager.FindByIdAsync(id);
            var specialist  = _allSpecialist.Specialists.SingleOrDefault(x=>x.Id== id); //получение мастера по айди
            if (specialist == null)
            {
                return NotFound();
            }
            EditSpecialistViewModel model = new EditSpecialistViewModel { SpecialistId= id,Name = specialist.Name, SurName=specialist.SurName, FullName=specialist.FullName, CategoryName=specialist.CategoryName,
                                                                             Phone=specialist.Phone, Experience=specialist.Experience};
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditSpecialistViewModel model)//получение новых данных и сохрагнение изменений
        {
            if (ModelState.IsValid)
            {
                var specialist = _allSpecialist.Specialists.SingleOrDefault(x => x.Id == model.SpecialistId);
              
                if (specialist != null)
                {
                    specialist.Name = model.Name;
                    specialist.SurName = model.SurName;
                    specialist.FullName = model.FullName;
                    specialist.CategoryName = model.CategoryName;
                    specialist.Phone = model.Phone;
                    specialist.Experience = model.Experience;
                   

                    _allSpecialist.Update(specialist);
                    return RedirectToAction("List");
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var specialist = _allSpecialist.Specialists.SingleOrDefault(x => x.Id == id);
            if (specialist != null)
                specialist.isDelete = true;


            return RedirectToAction("Index", "Home");
        }
    }
}
