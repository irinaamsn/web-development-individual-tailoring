using Gibrid.VewModels;

namespace Gibrid.Models.Interfaces
{
    public interface IAllSpecialist
    {
        public void createSpecialist(SpecialistViewModel specialist);//метод создания мастера
        public IEnumerable<CategorySpecialist> Categories { get; }//метод получения категорий
        public IEnumerable<Specialist> Specialists { get; }//получение списка специалистов
        public Specialist getObjectSpecialist(int spId);//получение мастера по айди
        public IEnumerable<Time> SpecialistTimes(int id);//получение списка времени по айди мастера
        public void Update(Specialist specialist);//обновление данных специалиста
        public void Delete(Specialist specialist);       //удаление мастера
        public void ChangeRating(Specialist specialist, int rating);//изменение рейтинга мастера

    }
}
