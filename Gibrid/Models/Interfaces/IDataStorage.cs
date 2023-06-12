namespace Gibrid.Models.Interfaces
{
    public interface IDataStorage
    {
        public DataStorageItem AddToStorage(SignUpDetail signUpDetail);
        public void DeleteData(DataStorageItem item);
        public IEnumerable<DataStorageItem> allDataStorages { get; }
    }
}
