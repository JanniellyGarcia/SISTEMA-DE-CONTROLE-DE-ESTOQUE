using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // Interaface de Repositório de Estoque.
    public interface IInventoryRepository 
    {
        // lista todos os estoques existentes.
        IEnumerable<Inventory> Get();

        // Retorna um estoque pelo id passado.
        Inventory GetInventoryById(int id);    

    }
}
