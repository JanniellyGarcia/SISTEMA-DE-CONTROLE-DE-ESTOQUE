using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    //Model de saída.
    public class Output : BaseEntity
    {

        // Chave primária da saída.
        public int IdOutput { get; set; }

        //Chave estrangeira que vem de Produto.
        public int ProductId { get; set; }
        public Product Product { get; set; }

        //Chave estrangeira de Empresa.
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        //Quantidade de produtos que entrarão:
        public int Quantity { get; set; }

        //Tipo de saída: Estorno ou saída.
        public OutputType OutputStatus { get; set; }

        public enum OutputType
        {
            outputOk = 1,
            reversal = 2
        };
    }
}
