using Gibrid.VewModels;

namespace Gibrid.Models.Interfaces
{
    public interface IReview
    {
        public void createReview(ReviewViewModel reviews, User user, int spId, int rating);
        public void DeleteReviews(Reviews item);
        public IEnumerable<Reviews> allReviewsDetails { get; }
    }
}
