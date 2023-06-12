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
        //private readonly IUser userresp;
        public Reseption(AppDBContent content)
        {
            _content = content;
        }
        public string ReseptionId { get; set; }
        //public List<ReseptionItem> listReseptionItems { get; set; }
        public ReseptionItem ReseptionItem { get; set; }
        public static Reseption GetReseption(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDBContent>();
            string reseptionId = session.GetString("reseptionId") ?? Guid.NewGuid().ToString();
            session.SetString("reseptionId", reseptionId);
            return new Reseption(context) { ReseptionId = reseptionId };
        }
        public ReseptionItem AddToReseption(Specialist specialist, DateTime time, string idUser, int timeId)
        {
            //  _content.TimeDetails.Add(time);

            var item = new ReseptionItem
            {
                ReseptionId = ReseptionId,
                SpecialistId = specialist.Id,
                SpecialistName = specialist.Name,
                Time = time,
                TimeId=timeId,
                userId = idUser,

            };
            _content.ReseptionItem.Add(item);
            _content.SaveChanges();
            return item;
        }
        public void DeleteFromReseption(int id)
        {
            //  _content.TimeDetails.Add(time);
            var item = _content.ReseptionItem.SingleOrDefault(x => x.Id == id);
            _content.ReseptionItem.Remove(item);

            _content.SaveChanges();
        }
        //public void DeleteTime(int IdTime)//Time && TimeDetails
        //{

        //    var timedet = _content.TimeDetails.SingleOrDefault(x=>x.Id==IdTime);
        //    _content.TimeDetails.Remove(timedet);
        //    var timeID = _content.TimeDetails.SingleOrDefault(x => x.Id == IdTime).TimeId;
        //    var time = _content.Time.SingleOrDefault(x => x.Id == timeID);
        //    _content.Time.Remove(time);
        //    _content.SaveChanges();
        //}
        public ReseptionItem getReseptionItem()
        {
            var list = _content.ReseptionItem.SingleOrDefault(c => c.ReseptionId == ReseptionId);
            return list;
        }

    }
}
