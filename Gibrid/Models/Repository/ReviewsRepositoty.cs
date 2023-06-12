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
            
            _content.Reviews.Add(revObj);
            _content.SaveChanges();
        }
        public void DeleteReviews(Reviews item)
        {
            item.isDelete = true;
            _content.Update(item);
            _content.SaveChanges();
        }
        public IEnumerable<Reviews> allReviewsDetails => _content.Reviews;
    }
}
