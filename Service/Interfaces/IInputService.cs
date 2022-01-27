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
        //Lista todos os inputs
        IEnumerable<InputViewModel> GetInputs();

        //valida a quantidade de entrada.
        public bool validationQuantity(Input input);

        //retorna a quantidade de entrada que foi deletada.
        public int QuantityDelete(int obj);

        //retorna o produto da entrada pelo nome.
        public Product GetProductByNameInInput(string nameProduct);
        // verifica se já existe no estoque algum produto da empresa em questão que se deseja adicionar(entrar).
        public bool CheckWhenAddQuantityInInventory(Input input);
    }
}
