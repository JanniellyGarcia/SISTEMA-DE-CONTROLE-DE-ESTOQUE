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
        // Lista os produtos existentes.
        IEnumerable<Product> GetProduct();

        // Retorna um porduto pelo seu id.
        Product GetProductById(int id);

        // Retorna um produto pelo nome.
        Product GetProductByName(string NameProduct);
    }
}
