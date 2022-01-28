using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    // Interface de saerviço de estoque.
    public interface IInventoryService
    {
        // Chamada para o método de listar os estoques.
        IEnumerable<InventoryViewModel> GetInventories();
       
    }
}
