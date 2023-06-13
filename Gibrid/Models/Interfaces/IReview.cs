using Gibrid.VewModels;

namespace Gibrid.Models.Interfaces
{
    public interface IReview
    {
        public void createReview(ReviewViewModel reviews, User user, int spId, int rating);//создание отзыва
        public void DeleteReviews(Reviews item);//удаление отзыва
        public IEnumerable<Reviews> allReviewsDetails { get; }//получение всех отзывов
    }
}
