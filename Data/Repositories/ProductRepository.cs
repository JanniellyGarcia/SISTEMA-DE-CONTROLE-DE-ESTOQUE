using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    // Repositório de Produto.
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SqlContext context) : base(context)
        {

        }
        // Implementação do método de listar os produtos qu existem nos bancos.
        public IEnumerable<Product> GetProduct()
        {
            
            var obj = CurrentSet
                .ToList();
            return obj;
        }

        // Implementação do método de buscar o produto pelo seu id.
        public Product GetProductById(int Id)
        {
            var obj = CurrentSet
                .Where(x => x.IdProduct == Id)
                .FirstOrDefault();
            return obj;
        }

        // Implementação do método de buscar o porduto pelo seu nome.
        public Product GetProductByName(string NameProduct)
        {
            var obj = CurrentSet
                 .Where(x => x.NameProduct == NameProduct.ToUpper())
                 .FirstOrDefault(); 
            return obj;
        }
            

    }
}
