using Gibrid.Models.Interfaces;
using Gibrid.VewModels;

namespace Gibrid.Models.Repository
{
    public class TimeRepository:IListTime
    {
        private readonly AppDBContent _content;
        private readonly IAllSpecialist spRep;
        public TimeRepository(AppDBContent content, IAllSpecialist spRep)
        {
            _content = content;
            this.spRep = spRep;
        }
        public void createTime(TimeViewModel time, int idSpDet)
        {
            var timeDetails = new Time()
            {
                TimeSpecialist = time.Time,
                SpecialistDetailsId = idSpDet,
                isActive=true

            };
            _content.Time.Add(timeDetails);//добавление времени в соответствующую таблицу в БД

            spRep.getObjectSpecialist(idSpDet).TimeS.ToList().Add(timeDetails);
            var specialist = spRep.getObjectSpecialist(idSpDet);//получение мастера по айди
            specialist.isHasTime = true;
            _content.SaveChanges();//сохранение изменений в БД
        }
        public void DeleteTime(int idTimeDet)// TimeDetail
        {
            var timedet = getObjectTimeDetail(idTimeDet);
            timedet.isDelete = true;//установка статуса удаления
            _content.Update(timedet);//обновление времени в БД
            _content.SaveChanges();//сохранение изменений в БД
        }
        public void ReturnTime(int timeId)
        {
            var time = _content.Time.SingleOrDefault(x => x.Id == timeId);
            time.isDelete = false;//установка статуса удаления
            _content.Update(time);//обновление времени в БД
            _content.SaveChanges();//сохранение изменений в БД
        }
        public Time getObjectTimeDetail(int id) => _content.Time.SingleOrDefault(x => x.Id == id);//получение времени по айди мастера из БД

        public IEnumerable<Time> getAllTimeDetails => _content.Time;//получение всего времени из БД

    }
}
