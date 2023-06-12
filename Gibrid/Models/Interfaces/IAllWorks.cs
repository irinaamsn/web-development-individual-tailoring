using Gibrid.VewModels;

namespace Gibrid.Models.Interfaces
{
    public interface IAllWorks
    {
        public void createWork(WorkViewModel work, string id);
        public void Delete(Works work);
        public IEnumerable<Works> WorksDetails { get; }
    }
}
