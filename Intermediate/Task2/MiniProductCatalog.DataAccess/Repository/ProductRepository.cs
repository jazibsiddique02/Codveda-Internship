using Microsoft.AspNetCore.Mvc;
using MiniProductCatalog.DataAccess.Data;
using MiniProductCatalog.DataAccess.Repository.Interface;
using MiniProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProductCatalog.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

        public void Update(Product entity)
        {
           _context.Products.Update(entity);
        }
    }
}
