using Grpc.Core;
using ProductService.Grpc;
using ProductService.Repositories;

namespace ProductService.Services;

public class ProductGrpcService : ProductGrpc.ProductGrpcBase
{
    private readonly IProductRepository _repository;

    public ProductGrpcService(IProductRepository repository)
    {
        _repository = repository;
    }

    public override Task<ProductResponse> GetProductById(ProductRequest request, ServerCallContext context)
    {
        var product = _repository.GetById(request.Id);
        return Task.FromResult(new ProductResponse
        {
            Id = product?.Id ?? 0,
            Name = product?.Name ?? "",
            Exists = product != null
        });
    }
}
