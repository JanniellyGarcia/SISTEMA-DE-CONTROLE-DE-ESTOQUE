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
    public class OutputRepository : BaseRepository<Output>, IOutputRepository
    {
        public OutputRepository(SqlContext sqlContext) : base(sqlContext)
        {
        }

        public IEnumerable<Output> GetOutput()
        {
            var obj = CurrentSet
                .Include(x => x.Company)
                .Include(x => x.Product)
                .ToList();
            return obj;
        }

        public Output GetOutputById(int id)
        {
            var obj = CurrentSet
                 .Where(x => x.IdOutput == id)
                 .FirstOrDefault();
            return obj;
        }
 
        
        public Output GetProductByIdInOutput(int id)
        {
            var product = CurrentSet
                .Where(x => x.ProductId == id)
                 .FirstOrDefault();
            return product;
        }

     
    }
}
