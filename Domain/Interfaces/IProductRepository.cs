using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // Interface do Repositório de Produto.
    public interface IProductRepository
    {
        IEnumerable<Product> GetProduct();
        Product GetProductById(int id);
        Product GetProductByName(string NameProduct);
    }
}
