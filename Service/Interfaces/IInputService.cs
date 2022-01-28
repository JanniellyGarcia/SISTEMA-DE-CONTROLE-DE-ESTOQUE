using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    // Interface de Serviço de Entrada;
    public interface IInputService
    {
        // Lista todos os inputs
        IEnumerable<InputViewModel> GetInputs();

        // Valida a quantidade de entrada.
        public bool validationQuantity(Input input);

        // Retorna o produto da entrada pelo nome.
        public Product GetProductByNameInInput(string nameProduct);
        // Verifica se já existe no estoque algum produto da empresa em questão que se deseja adicionar(entrar).
        public bool CheckWhenAddQuantityInInventory(Input input);
    }
}
