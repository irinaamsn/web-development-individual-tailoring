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

        public DataStorageItem AddToStorage(SignUpDetail signUpDetail)
        {
          //  signUpDetail.isServiced = true;
            var userId = signUpDetail.UserId;
            var specialist = spRep.getObjectSpecialist(signUpDetail.SpecialistId);


            var data = new DataStorageItem
            {
                SpecialistId = signUpDetail.SpecialistId,
                SpecialistName = signUpDetail.SpecialistName,
                Time = signUpDetail.Time,
                CategoryName = specialist.CategoryName,
                UserId = userId,
                isServiced = false,
                //isRate = false
            };
            _content.DataStorageItem.Add(data);
           _content.SaveChanges();
            return data;
        }
        public void DeleteData(DataStorageItem item)
        {
            item.isDelete = true;
            _content.Update(item);
            _content.SaveChanges();
        }
        public IEnumerable<DataStorageItem> allDataStorages => _content.DataStorageItem;
       
    }
}
