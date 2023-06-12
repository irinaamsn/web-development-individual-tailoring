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
            _content.Time.Add(timeDetails);

            spRep.getObjectSpecialist(idSpDet).TimeS.ToList().Add(timeDetails);//???
            var specialist = spRep.getObjectSpecialist(idSpDet);
            specialist.isHasTime = true;
            _content.SaveChanges();
        }
        public void DeleteTime(int idTimeDet)// TimeDetail
        {
            var timedet = getObjectTimeDetail(idTimeDet);
            timedet.isDelete = true;
            _content.Update(timedet);
            _content.SaveChanges();
        }
        //public void DeleteTime(int idTimeDet)//Time 
        //{
        //    var timedet = getObjectTimeDetail(idTimeDet);
        //    var timeID = _content.TimeDetails.SingleOrDefault(x => x.Id == idTimeDet).TimeId;
        //    var timeObj = getObjectTime(timeID);
        //    _content.Time.Remove(timeObj);
        //    _content.SaveChanges();
        //}
        public void ReturnTime(int timeId)
        {
            var time = _content.Time.SingleOrDefault(x => x.Id == timeId);
            time.isDelete = false;
            _content.Update(time);
            _content.SaveChanges();
        }
        public Time getObjectTimeDetail(int id) => _content.Time.SingleOrDefault(x => x.Id == id);

       // public Time getObjectTime(int TimeId) => _content.Time.SingleOrDefault(x => x.Id == TimeId);
        public IEnumerable<Time> getAllTimeDetails => _content.Time;

    }
}
