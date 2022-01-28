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
        // Chamada para o método de listar os prodtos.
        IEnumerable<ProductViewModel> GetProduct();

        // Chamada para o método validação de produto. (Não podem existir  dois produtos com mesmo nome.)
        public bool ValidationAddProduct(string name, int id);
    }
}
