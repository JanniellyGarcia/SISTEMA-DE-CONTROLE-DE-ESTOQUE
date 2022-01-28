using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // Interface do Repositório de Saída.
    public interface IInputRepository
    {
        // Chamada para o método de listar todos os usuários.
        IEnumerable<Input> GetInput();

        // Chamada para pegar a entrada pelo seu id.
        Input GetInputById(int id);

        // retorna o produto na barra de pesquisa da página de entradas.
        public Input GetProductByIdInInput(int id);


    }
}
