using Gibrid.Models.Interfaces;
using Microsoft.Ajax.Utilities;

namespace Gibrid.Models.Repository
{
    public class DataStorageRepository:IDataStorage
    {
        private readonly AppDBContent _content;
        private readonly IAllSpecialist spRep;

        public DataStorageRepository(AppDBContent content, IAllSpecialist spRep)
        {
            _content = content;
            this.spRep = spRep;

        }

        public DataStorageItem AddToStorage(SignUpDetail signUpDetail)//добавление записи в архив записей клиента в его ЛК
        {
            var userId = signUpDetail.UserId;//получение айди клиента
            var specialist = spRep.getObjectSpecialist(signUpDetail.SpecialistId);//получение мастера
            var data = new DataStorageItem
            {
                SpecialistId = signUpDetail.SpecialistId,
                SpecialistName = signUpDetail.SpecialistName,
                Time = signUpDetail.Time,
                CategoryName = specialist.CategoryName,
                UserId = userId,
                isServiced = false
            };
            _content.DataStorageItem.Add(data);//добавление в соответствующую таблицу в БД
           _content.SaveChanges();//сохранение изменений в БД
            return data;
        }
        public void DeleteData(DataStorageItem item)//удаление записи
        {
            item.isDelete = true;//установка статуса удаения
            _content.Update(item);//обновление данных этой записи в БД
            _content.SaveChanges();//сохранение изменений в БД
        }
        public IEnumerable<DataStorageItem> allDataStorages => _content.DataStorageItem;//получение всех записей из архива из БД
       
    }
}
