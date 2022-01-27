using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    // Model de entrada:
    public class Input : BaseEntity
    {
        // Id da entrada.
        public int IdInput { get; set; }

        //Chave estrangeira de Produto.
        public int ProductId { get; set; }
        public Product product { get; set; }

        //Chave estrangeira de Empresa.
        public int CompanyId { get; set; } 
        public Company company { get; set; }

        //Quantidade de produtos que entrarão:
        public int Quantity { get; set; }   

    }
}
