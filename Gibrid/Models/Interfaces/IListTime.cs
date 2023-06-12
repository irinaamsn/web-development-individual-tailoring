using Gibrid.VewModels;

namespace Gibrid.Models.Interfaces
{
    public interface IListTime
    {
        public void createTime(TimeViewModel time,int idSpDet);
        public void DeleteTime(int idTimeDet);
      
        public Time getObjectTimeDetail(int id);
        //public Time getObjectTime(int TimeId);
        public IEnumerable<Time> getAllTimeDetails { get; }

        public void ReturnTime(int timeId);
    }
}
