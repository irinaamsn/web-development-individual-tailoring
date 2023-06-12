using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Gibrid.Models.Interfaces;

namespace Gibrid.Models
{
    public class DbObjects
    {
        //public static void Initial(AppDBContent content)
        //{
        //    if (!content.ServiceDetail.Any())
        //    {
        //        content.AddRange(
        //            new Service { Name = "Пошив партий средним и крупным оптом", ShortDesc = "От 60 единиц на модель и цвет. Можем взять в работу Ваши лекала или разработать сами.", 
        //                Img = "/images/noun-tailor-1959587.png"},
        //            new Service
        //            {
        //                Name = "Разработка лекал и технической документации",
        //                ShortDesc = "Производится профессиональным конструктором с помощью современных дигитайзера и плоттера с градацией размеров",
        //                Img = "/images/noun-blueprint-36945.png"},
        //            new Service
        //            {
        //                Name = "Подбор тканей и фурнитуры",
        //                ShortDesc = "Дизайнер с многолетним опытом подберет ткани и фурнитуру, которые идеально подойдут для реализации Ваших идей",
        //                Img = "/images/noun-textile-fabric-.png"
        //            }
        //            );
        //    }
        //    content.SaveChanges();

        //}
      
        //private static Dictionary<string, Category> _categories;
        //public static Dictionary<string,Category> Categories
        //{
        //    get
        //    {
        //        if (_categories == null)
        //        {
        //            var list = new Category[]
        //            {
        //                new Category { Name = "Electro", desc = "new cars in 2022" },
        //                new Category { Name = "Classic", desc = "cars in all" }
        //            };
        //            _categories = new Dictionary<string, Category>();
        //            foreach (var category in list)
        //                _categories.Add(category.Name, category);
        //        }
        //        return _categories;
        //    }
        //}

        //public static void CategoriesSpecialist(AppDBContent content)
        //{
        //   if (!content.CategorySpecialist.Any())
        //   {
        //        content.AddRange(
        //        new CategorySpecialist { Name = "Ученик",isEmpty=false},
        //        new CategorySpecialist { Name = "Мастер высшей категории", isEmpty = false },
        //        new CategorySpecialist { Name = "Профессионал", isEmpty = false }
        //        );

        //    }
        //    content.SaveChanges();
        //}


 
    }
}
