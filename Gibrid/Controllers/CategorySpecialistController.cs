using Gibrid.Models.Interfaces;
using Gibrid.Models;
using Gibrid.VewModels;
using Microsoft.AspNetCore.Mvc;

namespace Gibrid.Controllers
{
    public class CategorySpecialistController:Controller//категория мастера
    {
        private readonly ISpecialistCategory _categoryRepos;
        public CategorySpecialistController(ISpecialistCategory categoryRepos)
        {
            _categoryRepos = categoryRepos;
        }

        public ViewResult List()//получение списка доступных категорий
        {

            var list = _categoryRepos.AllCategories;//лист категорий

            return View(list);
        } 

    }
}
