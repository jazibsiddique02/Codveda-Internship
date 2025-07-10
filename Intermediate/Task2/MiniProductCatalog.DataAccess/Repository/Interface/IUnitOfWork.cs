using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProductCatalog.DataAccess.Repository.Interface
{
    public interface IUnitOfWork 
    {
        IProductRepository productRepository { get; }
        void Save();
    }
}
