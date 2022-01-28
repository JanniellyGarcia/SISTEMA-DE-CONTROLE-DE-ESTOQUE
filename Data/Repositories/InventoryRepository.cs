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
    //Repositório de Estoque.
    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(SqlContext sqlContext) : base(sqlContext)
        {
        }
        // Implementação do método de Listar os estoques existentes.
        public IEnumerable<Inventory> GetInventory()
        {
            var obj = CurrentSet
                .Include(x => x.Product_)
                .Include(x => x.Company_)
                .ToList();
            return obj; 
                
        }

        // Impelemtação do método de buscar o estoque pelo seu Id.
        public Inventory GetInventoryById(int id)
        {
            var obj = CurrentSet
                .Where(x => x.IdInventory == id)
                .FirstOrDefault();
            return obj;
        }
    }
}
