using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    // Interface de Serviço de Produto.
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetProduct();
        public bool ValidationAddProduct(string name, int id);
    }
}
