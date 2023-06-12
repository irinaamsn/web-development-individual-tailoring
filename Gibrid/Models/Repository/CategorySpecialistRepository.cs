using Gibrid.Models.Interfaces;
using Gibrid.VewModels;

namespace Gibrid.Models.Repository
{
    public class CategorySpecialistRepository : ISpecialistCategory
    {
        private readonly AppDBContent _content;

        public CategorySpecialistRepository(AppDBContent content)
        {
            _content = content;
        }
        public void createCategory(CategorySpecialistViewModel categorySp)
        {
           
            var categoryDetails = new CategorySpecialist()
            {
                Name = categorySp.Name,
                isEmpty = false,
            };
            _content.CategorySpecialist.Add(categoryDetails);
            // }
            _content.SaveChanges();
        }
        public IEnumerable<CategorySpecialist> AllCategories => _content.CategorySpecialist;
    }
}
