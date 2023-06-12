using System.ComponentModel.DataAnnotations;

namespace Gibrid.Models.Enum
{
    public enum EnumCategorySpecialist
    {

        [Display(Name = "Ученик")]
        Ученик,
        [Display(Name = "Мастер высшей категории")]
        МастерВысшейКатегории,
        [Display(Name = "Профессионал")]
        Профессионал,
    }
}
