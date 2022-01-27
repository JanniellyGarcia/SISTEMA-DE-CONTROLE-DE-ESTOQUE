using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // Interface do Repositório da Base.
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity obj);
        void Update(TEntity obj);   
        void Delete(int Id);   
        IList<TEntity> Select();
        TEntity Select(int id);    
    }
    
}
