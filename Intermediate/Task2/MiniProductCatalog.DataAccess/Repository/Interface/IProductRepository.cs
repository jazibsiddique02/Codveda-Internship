using Microsoft.AspNetCore.Mvc;
using MiniProductCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProductCatalog.DataAccess.Repository.Interface
{
    public interface IProductRepository : IRepository<Product> 
    {
        void Update(Product entity);

    }
}
