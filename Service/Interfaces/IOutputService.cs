using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // Interface de Serviço de saída;
    public interface IOutputService
    {
        // Chamada para o método de listar as saídas.
        IEnumerable<OutputViewModel> GetOutput();

        // Validação de saída:
        public bool OutputValidation(Output output);

        // Valiação de quantidade(>0):
        public bool ValidationQuantity(Output output);

        // Validação da quantidade em estoque (verifica se a quantidade em estoque é sufuciente para realizar uma saída)
        public bool ValidationQuantityInInventory(Output output);

        // Retorna o produto da saída pelo nome.
        public Product GetProductByNameInOutput(string name);

    }
}
