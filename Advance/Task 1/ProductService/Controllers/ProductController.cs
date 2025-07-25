using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Repositories;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_repository.GetAll());

    [HttpPost]
    public IActionResult Add(Product product)
    {
        _repository.Add(product);
        return Ok();
    }

    [HttpGet("/health")]
    public IActionResult Health() => Ok("Healthy");

}
