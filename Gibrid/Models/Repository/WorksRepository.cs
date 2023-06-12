using Gibrid.Models.Interfaces;
using Gibrid.VewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            _content.Works.Add(workDetail);
            specialist.listWorksDetails.Add(workDetail);
            _content.SaveChanges();
           
        }
        public void Delete(Works work)
        {
           work.isDelete = true;
            _content.Update(work);
            _content.SaveChanges();
        }
        public IEnumerable<Works> WorksDetails => _content.Works;
        //public IEnumerable<Works> Works=> _content.WorksDetails;
    }
}
