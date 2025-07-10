using MiniProductCatalog.DataAccess.Data;
using MiniProductCatalog.DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProductCatalog.DataAccess.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        
        public IProductRepository productRepository { get; }


        public UnitOfWork( ApplicationDbContext context)
        {
            _context = context;
            productRepository = new ProductRepository(context);
        }


        public void Save() 
        { 
            _context.SaveChanges();
        }
    }
}
