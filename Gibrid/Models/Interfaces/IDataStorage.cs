namespace Gibrid.Models.Interfaces
{
    public interface IDataStorage
    {
        public DataStorageItem AddToStorage(SignUpDetail signUpDetail);// Добавление записи в архив
        public void DeleteData(DataStorageItem item);//удаление записи из архива
        public IEnumerable<DataStorageItem> allDataStorages { get; }//получение всех записей в архиве пользователя
    }
}
