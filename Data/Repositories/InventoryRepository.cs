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
    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(SqlContext sqlContext) : base(sqlContext)
        {
        }

        public IEnumerable<Inventory> GetInventory()
        {
            var obj = CurrentSet
                .ToList();
            return obj; 
                
        }

        public Inventory GetInventoryById(int id)
        {
            var obj = CurrentSet
                .Where(x => x.IdInventory == id)
                .FirstOrDefault();
            return obj;
        }
    }
}
