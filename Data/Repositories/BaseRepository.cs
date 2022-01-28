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
    // Repositório base.
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqlContext _sqlContext;
        protected readonly DbSet<TEntity> CurrentSet;

        public BaseRepository(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
            CurrentSet = sqlContext.Set<TEntity>();
        }

        // Implemetação do método de add.
        public void Insert(TEntity obj)
        {
            _sqlContext.Set<TEntity>().Add(obj);
            _sqlContext.SaveChanges();
        }

        // Implemetação do método de atualizar.
        public void Update(TEntity obj)
        {
            _sqlContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlContext.SaveChanges();
        }

        // Implemetação do método de deletar.
        public void Delete(int id)
        {
            _sqlContext.Set<TEntity>().Remove(Select(id));
            _sqlContext.SaveChanges();
        }

        // Implemetação do método de listar.
        public IList<TEntity> Select() =>
            _sqlContext.Set<TEntity>().ToList();

        // Implemetação do método que retorna a entidade pelo seu id.
        public TEntity Select(int id) =>
            _sqlContext.Set<TEntity>().Find(id);

    }
}
