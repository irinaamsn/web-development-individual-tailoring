using Gibrid.Models.Interfaces;
using Gibrid.Models;
using Gibrid.VewModels;
using Microsoft.AspNetCore.Mvc;

namespace Gibrid.Controllers
{
    public class CategorySpecialistController:Controller
    {
        private readonly ISpecialistCategory _categoryRepos;
        public CategorySpecialistController(ISpecialistCategory categoryRepos)
        {
            _categoryRepos = categoryRepos;
        }

        public ViewResult List()
        {

            var list = _categoryRepos.AllCategories;

            return View(list);
        } 

    }
}
