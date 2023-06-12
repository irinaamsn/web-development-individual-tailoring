using Gibrid.Models.Interfaces;
using Gibrid.Models;
using Gibrid.VewModels;
using Microsoft.AspNetCore.Mvc;

namespace Gibrid.Controllers
{
    public class TimeController:Controller
    {
        private readonly IAllSpecialist _allSpecialist;
        private readonly IListTime timeRepos;

        public TimeController(IAllSpecialist allSpecialist, IListTime timeRepos)
        {
            _allSpecialist = allSpecialist;
            this.timeRepos = timeRepos;
        }
        //public ViewResult List(int id)//idSpecialist
        //{
        //    var sp = _allSpecialist.getObjectSpecialist(id);
          
        //    var times = _allSpecialist.SpecialistTimes(id).ToList();
        //    sp.TimeS = times;


        //    return View(times);
        //}
    }
}
