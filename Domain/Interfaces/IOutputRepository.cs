using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    //Interface do Repositório de Saída.
    public interface IOutputRepository
    {
        //Lista todos as Saídas.
        IEnumerable<Output> GetOutput();

        //Pega a Saída pelo Id indicado.
        Output GetOutputById(int id);

        // retorna o produto na barra de pesquisa da página de saída.
        public Output GetProductByIdInOutput(int id);
    }
}
