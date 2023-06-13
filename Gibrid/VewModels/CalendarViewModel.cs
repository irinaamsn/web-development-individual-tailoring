using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class CalendarViewModel
    {
        public List<SignViewModel> signViewModels { get; set; }//коллекция модели SignViewModel, содержащая всю нужную информацию записи для страницы
        public List<Time> times { get; set; }//коллекция всего времени Time из БД
    }
}
