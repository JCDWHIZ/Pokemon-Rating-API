using System;
using ProductsApi.Data;
using ProductsApi.Interfaces;
using ProductsApi.Models;

namespace ProductsApi.Repository;

public class ReviewRepository(DataContext context) : IReviewRepository
{
    private readonly DataContext _context = context;

    public bool CreateReview(Review review)
    {
        _context.Reviews.Add(review);
        return Save();
    }

    public bool DeleteReview(Review review)
    {
        _context.Remove(review);
        return Save();
    }

    public bool DeleteReviews(List<Review> reviews)
    {
        _context.RemoveRange(reviews);
        return Save();
    }

    public Review GetReview(int reviewId)
    {
        return _context.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
    }

    public ICollection<Review> GetReviews()
    {
        return _context.Reviews.ToList();
    }

    public ICollection<Review> GetReviewsOfAPokemon(int PokeId)
    {
        return _context.Reviews.Where(r => r.Pokemon.Id == PokeId).ToList();
    }

    public bool ReviewExists(int reviewId)
    {
        return _context.Reviews.Any(r => r.Id == reviewId);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdatedReview(Review review)
    {
        _context.Update(review);
        return Save();
    }
}
