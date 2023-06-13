using Gibrid.Models;

namespace Gibrid.VewModels
{
    public class CreateSignUpViewModel
    {
        public SignUp SignUp { get; set; }//запись
        public ReseptionItem ReseptionItems { get; set; }//"корзина" - мастер и время
        public Specialist Specialist { get; set; }//мастер
        public int TimeId { get; set; }//ID времени
        public IEnumerable<Time> allTimeSpecialist { get; set; }//коллекция Time мастера
    }
}
