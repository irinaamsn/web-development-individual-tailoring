using System.ComponentModel.DataAnnotations;

namespace Gibrid.Models.Enum
{
    public enum EnumCategorySpecialist// перечисление, содержит категории мастеров
    {

        [Display(Name = "Ученик")]
        Ученик,
        [Display(Name = "Мастер высшей категории")]
        МастерВысшейКатегории,
        [Display(Name = "Профессионал")]
        Профессионал,
    }
}
