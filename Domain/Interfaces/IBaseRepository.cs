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
        // Chamada para método de adição da entidade ao banco.
        void Insert(TEntity obj);


        // Chamada para método de atualização da entidade ao banco.
        void Update(TEntity obj);

        // Chamada para método de Deletar a entidade do banco.
        void Delete(int Id);

        // Chamada para método de Listar as entidades do banco.
        IList<TEntity> Select();

        // Chamada para método de buscar a entidade pelo seu id no banco.
        TEntity Select(int id);    
    }
    
}
