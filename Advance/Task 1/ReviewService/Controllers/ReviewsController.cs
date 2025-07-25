using ProductService.Grpc; // Generated from proto
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using ReviewService.Models;
using ReviewService.Repositories;

namespace ReviewService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewRepository _repository;
    private readonly ProductService.Grpc.ProductGrpc.ProductGrpcClient _grpcClient;

    public ReviewsController(IReviewRepository repository, ProductService.Grpc.ProductGrpc.ProductGrpcClient grpcClient)
    {
        _repository = repository;
        _grpcClient = grpcClient;
    }

    [HttpGet("{productId}")]
    public IActionResult GetReviewsForProduct(int productId)
    {
        var reviews = _repository.GetReviewsForProduct(productId);
        return Ok(reviews);
    }

    [HttpPost]
    public async Task<IActionResult> AddReview(Review review)
    {
        // Validate product exists using gRPC call to ProductService
        var response = await _grpcClient.GetProductByIdAsync(new ProductRequest { Id = review.ProductId });
        if (!response.Exists)
            return BadRequest($"Product with ID {review.ProductId} does not exist.");

        _repository.AddReview(review);
        return Ok();
    }


    [HttpGet("/health")]
    public IActionResult Health() => Ok("Healthy");

}
