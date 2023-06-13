using Gibrid.Models.Interfaces;
using Gibrid.VewModels;

namespace Gibrid.Models.Repository
{
    public class CategorySpecialistRepository : ISpecialistCategory//реализация интерфейса
    {
        private readonly AppDBContent _content;

        public CategorySpecialistRepository(AppDBContent content)
        {
            _content = content;
        }
        public void createCategory(CategorySpecialistViewModel categorySp)//создание категории
        {
           
            var categoryDetails = new CategorySpecialist()
            {
                Name = categorySp.Name,
                isEmpty = false,
            };
            _content.CategorySpecialist.Add(categoryDetails);//добавление в БД
            // }
            _content.SaveChanges();//сохраниние изменений в БД
        }
        public IEnumerable<CategorySpecialist> AllCategories => _content.CategorySpecialist;//все категории
    }
}
