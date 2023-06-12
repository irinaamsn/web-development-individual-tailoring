using Gibrid.VewModels;

namespace Gibrid.Models.Interfaces
{
    public interface IAllSpecialist
    {
        public void createSpecialist(SpecialistViewModel specialist);
        public IEnumerable<CategorySpecialist> Categories { get; }
        public IEnumerable<Specialist> Specialists { get; }
        public Specialist getObjectSpecialist(int spId);
        public IEnumerable<Time> SpecialistTimes(int id);
        public void Update(Specialist specialist);
        public void Delete(Specialist specialist);
       
        public void ChangeRating(Specialist specialist, int rating);
        //public void createSign(DataUser data);
        //public IEnumerable<ReseptionItem> ReseptionItems { get; }
    }
}
