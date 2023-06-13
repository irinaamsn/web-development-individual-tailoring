using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class UserViewModel
    {
        public SignUpDetail Sign { get; set; }//запись клиента
        public Time Time { get; set; }//текущее время в записи при наличии 
        public Specialist Specialist { get; set; }//мастер в записи при наличии
        public List<DataStorageItem> OldSigns { get; set; }//архив записей клиента
    }
}
