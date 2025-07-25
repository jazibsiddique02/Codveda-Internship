using ReviewService.Models;

namespace ReviewService.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly List<Review> _reviews = new();

    public IEnumerable<Review> GetReviewsForProduct(int productId)
    {
        return _reviews.Where(r => r.ProductId == productId);
    }

    public void AddReview(Review review)
    {
        review.Id = _reviews.Count + 1;
        _reviews.Add(review);
    }
}
