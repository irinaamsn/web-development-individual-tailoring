using Gibrid.VewModels;

namespace Gibrid.Models.Interfaces
{
    public interface ISpecialistCategory
    {
        public void createCategory(CategorySpecialistViewModel specialist);//создание категории мастера
        IEnumerable<CategorySpecialist> AllCategories { get; }//получение всех категорий
    }
}
