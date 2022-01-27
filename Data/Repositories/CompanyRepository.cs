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
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(SqlContext sqlContext) : base(sqlContext)
        {
        }

        public IEnumerable<Company> GetCompany()
        {
            var obj = CurrentSet
                .ToList();
            return obj;
        }

        public Company GetCompanyById(int id)
        {
            var obj = CurrentSet
              .Where(x => x.IdCompany == id)
              .FirstOrDefault();
            return obj;
        }

        public Company GetCompanyByName(string name)
        {
           
            var obj = CurrentSet
              .Where(x => x.NameCompany.Contains(name.ToUpper())  )
              .FirstOrDefault();
            return obj;
        }
        
    }
}
