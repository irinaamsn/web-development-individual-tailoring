using Gibrid.VewModels;

namespace Gibrid.Models.Interfaces
{
    public interface IAllWorks
    {
        public void createWork(WorkViewModel work, string id);//создание работы мастера
        public void Delete(Works work);//удаление работы
        public IEnumerable<Works> WorksDetails { get; }//получение всех работ
    }
}
