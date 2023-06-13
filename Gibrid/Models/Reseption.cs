using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
using Gibrid.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Ajax.Utilities;

namespace Gibrid.Models
{
    public class Reseption
    {
        private readonly AppDBContent _content;
        public Reseption(AppDBContent content)
        {
            _content = content;
        }
        public string ReseptionId { get; set; }
        public ReseptionItem ReseptionItem { get; set; }
        public static Reseption GetReseption(IServiceProvider service)//установка сессии
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string reseptionId = session.GetString("reseptionId") ?? Guid.NewGuid().ToString();
            session.SetString("reseptionId", reseptionId);
            return new Reseption(context) { ReseptionId = reseptionId };
        }
        public ReseptionItem AddToReseption(Specialist specialist, DateTime time, string idUser, int timeId)
        {

            var item = new ReseptionItem
            {
                ReseptionId = ReseptionId,
                SpecialistId = specialist.Id,
                SpecialistName = specialist.Name,
                Time = time,
                TimeId=timeId,
                userId = idUser,

            };
            _content.ReseptionItem.Add(item);//добавление "корзины" (мастер и время) в БД
            _content.SaveChanges();//сохранение изменений в БД
            return item;
        }
        public void DeleteFromReseption(int id)
        {
            var item = _content.ReseptionItem.SingleOrDefault(x => x.Id == id);//получение "корзины" (мастер и время) из БД
            _content.ReseptionItem.Remove(item);//удаление "корзины" (мастер и время) из БД

            _content.SaveChanges();//сохранение изменений в БД
        }
        public ReseptionItem getReseptionItem() => _content.ReseptionItem.SingleOrDefault(c => c.ReseptionId == ReseptionId);

    }
}
