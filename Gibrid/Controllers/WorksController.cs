using Gibrid.Models.Interfaces;
using Gibrid.VewModels;
using Microsoft.AspNetCore.Mvc;

namespace Gibrid.Controllers
{
    public class WorksController:Controller
    {
        private readonly IAllSpecialist _allSpecialist;
        private readonly IAllWorks _worksRepos;

        public WorksController(IAllSpecialist allSpecialist, IAllWorks works)
        {
            _allSpecialist = allSpecialist;
            _worksRepos = works;
        }
        public ViewResult List(int id)//метод для получение списка работ матсера по его айди
        {
            var listWorks = _worksRepos.WorksDetails.Where(x=>x.SpecialistId==id);//лист работ


            return View(listWorks);
        }
    }
}
