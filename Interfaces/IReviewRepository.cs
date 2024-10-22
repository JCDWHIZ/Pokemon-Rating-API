using System;
using ProductsApi.Models;

namespace ProductsApi.Interfaces;

public interface IReviewRepository
{
    ICollection<Review> GetReviews();
    Review GetReview(int reviewId);
    ICollection<Review> GetReviewsOfAPokemon(int PokeId);
    bool ReviewExists(int reviewId);
    bool CreateReview(Review review);
    bool UpdatedReview(Review review);
    bool DeleteReviews(List<Review> reviews);
    bool Save();
}
