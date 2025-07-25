using ProductService.Models;

namespace ProductService.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Pen" },
        new Product { Id = 2, Name = "Notebook" }
    };

        public IEnumerable<Product> GetAll() => _products;

        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

        public void Add(Product product) => _products.Add(product);
    }
}
