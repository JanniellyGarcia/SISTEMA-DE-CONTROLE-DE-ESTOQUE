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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SqlContext context) : base(context)
        {

        }
        public IEnumerable<Product> GetProduct()
        {
            
            var obj = CurrentSet
                .ToList();
            return obj;
        }

        public Product GetProductById(int Id)
        {
            var obj = CurrentSet
                .Where(x => x.IdProduct == Id)
                .FirstOrDefault();
            return obj;
        }

        public Product GetProductByName(string NameProduct)
        {
            var obj = CurrentSet
                 .Where(x => x.NameProduct == NameProduct.ToUpper())
                 .FirstOrDefault(); 
            return obj;
        }
            

    }
}
