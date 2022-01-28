using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // Interface de Serviço da Base.
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        // Chamada para método de adição da entidade ao banco.
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        // Chamada para método de Deletar a entidade do banco.
        void Delete(int id);

        // Chamada para método de Listar as entidades do banco.
        IList<TEntity> Get();

        // Chamada para método de buscar a entidade pelo seu id no banco.
        TEntity GetById(int id);

        // Chamada para método de atualização da entidade ao banco.
        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;


    }
}
