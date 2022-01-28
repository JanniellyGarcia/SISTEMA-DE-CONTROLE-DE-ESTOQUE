using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    // Repositório de entrada.
    public class InputRepository : BaseRepository<Input>, IInputRepository
    {
        public InputRepository(SqlContext sqlContext) : base(sqlContext)
        {
        }

        // Implemetação do método que retorna todos as entradas do BD.
        public IEnumerable<Input> GetInput()
        {
            var obj = CurrentSet
                .Include(x => x.product)
                .Include(x => x.company)
                .ToList();
            return obj;
        }

        // Implemetação do método que retorna uma entrada pelo seu id.
        public Input GetInputById(int id)
        {
            var obj = CurrentSet
              .Where(x => x.IdInput == id)
              .FirstOrDefault();
            return obj;
        }

        // Implemetação do método que retorna o produto da entrada pelo id.
        public Input GetProductByIdInInput(int id)
        {
            var product = CurrentSet
                .Where(x => x.ProductId == id)
                 .FirstOrDefault();
            return product;
        }

        // Implemetação do método que busca no banco de dados todo os produtos que entraram.
        public IEnumerable<Product> GetProductsInInput()
        {
            var obj = CurrentSet
                   .Select(x => x.product)
                   .ToList();
            return obj;
        }

        

    }
}
