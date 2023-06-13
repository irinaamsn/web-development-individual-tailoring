using Gibrid.VewModels;

namespace Gibrid.Models.Interfaces
{
    public interface IListTime
    {
        public void createTime(TimeViewModel time,int idSpDet);//создание времени для записи
        public void DeleteTime(int idTimeDet);//удаление времени     
        public Time getObjectTimeDetail(int id);//получение времени по айди мастера
        public IEnumerable<Time> getAllTimeDetails { get; }//получение всего времени из БД
        public void ReturnTime(int timeId);//возвращение времни в список для записи
    }
}
