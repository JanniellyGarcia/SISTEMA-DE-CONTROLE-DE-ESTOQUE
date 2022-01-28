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
    // Repositório de Saída.
    public class OutputRepository : BaseRepository<Output>, IOutputRepository
    {
        public OutputRepository(SqlContext sqlContext) : base(sqlContext)
        {
        }

        // Implementação do método de listar todos as saídas.
        public IEnumerable<Output> GetOutput()
        {
            var obj = CurrentSet
                .Include(x => x.Company)
                .Include(x => x.Product)
                .ToList();
            return obj;
        }

        // Implementação do método de buscar a entrada pelo seu id.
        public Output GetOutputById(int id)
        {
            var obj = CurrentSet
                 .Where(x => x.IdOutput == id)
                 .FirstOrDefault();
            return obj;
        }
 
        // Implemnetação do método que buscar por um produto pelo seu nome dentro da entidade de saída.
        public Output GetProductByIdInOutput(int id)
        {
            var product = CurrentSet
                .Where(x => x.ProductId == id)
                 .FirstOrDefault();
            return product;
        }

     
    }
}
