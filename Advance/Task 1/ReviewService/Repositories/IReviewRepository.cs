using ReviewService.Models;

namespace ReviewService.Repositories;

public interface IReviewRepository
{
    IEnumerable<Review> GetReviewsForProduct(int productId);
    void AddReview(Review review);
}
