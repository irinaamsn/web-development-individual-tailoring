using Gibrid.VewModels;

namespace Gibrid.Models.Interfaces
{
    public interface ISpecialistCategory
    {
        public void createCategory(CategorySpecialistViewModel specialist);
        IEnumerable<CategorySpecialist> AllCategories { get; }
    }
}
