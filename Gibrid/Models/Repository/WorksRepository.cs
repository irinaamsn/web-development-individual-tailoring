using Gibrid.Models.Interfaces;
using Gibrid.VewModels;

namespace Gibrid.Models.Repository
{
    public class WorksRepository:IAllWorks
    {
        private readonly AppDBContent _content;
        public WorksRepository(AppDBContent content)
        {
            _content = content;
        }
        public void createWork(WorkViewModel work, string id)
        {
            var specialist = _content.Specialist.SingleOrDefault(x => x.userId == id);
            byte[] imageData = null;
            if (work.Avatar != null)
            {                
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(work.Avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)work.Avatar.Length);
                }                
            }
            var workDetail = new Works
            {
                Image= imageData,
                SpecialistId=specialist.Id,
                Specialist=specialist,
                isBest=work.isFav
            };
            _content.Works.Add(workDetail);//добавление работы в БД
            specialist.listWorksDetails.Add(workDetail);
            _content.SaveChanges();//сохранение изменений в БД

        }
        public void Delete(Works work)
        {
           work.isDelete = true;//установка статуса удаления этой работы
            _content.Update(work);//обновление данных в таблицей с этой работой в БД
            _content.SaveChanges();//сохранение изменений в БД
        }
        public IEnumerable<Works> WorksDetails => _content.Works;//получение всех работ из БД
    }
}
