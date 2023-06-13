using Gibrid.Models.Interfaces;
using Gibrid.VewModels;
using Microsoft.AspNetCore.Identity;

namespace Gibrid.Models.Repository
{
    public class ReviewsRepository:IReview
    {
        private readonly AppDBContent _content;

        public ReviewsRepository(AppDBContent content)
        {
            _content = content;
        }

        public void createReview(ReviewViewModel reviews, User user, int spId, int rating)
        {                  
            var revObj = new Reviews
            {
                Text = reviews.Text,
                UserId = user.Id,
                UserName = user.UserName,
                SpecialistId = spId,
                Rating = rating,
                DateReview=DateTime.Now
            };
            
            _content.Reviews.Add(revObj);//добавление отзыва в соответствующую таблицу в БД
            _content.SaveChanges();//сохранение изменений в БД
        }
        public void DeleteReviews(Reviews item)
        {
            item.isDelete = true;//установка статуса удаления
            _content.Update(item);//обновление отзыва в БД
            _content.SaveChanges();//сохранение изменений в БД
        }
        public IEnumerable<Reviews> allReviewsDetails => _content.Reviews;//получение всех отзывов из БД
    }
}
