using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    // Model de Estoque:
    public class Inventory : BaseEntity
    {
        // Indentificador de Estoque:
        public int IdInventory { get; set; }

        // Referência a classe de porduto:
        public int ProductId { get; set; }
        public Product Product_ { get; set; }

        // Referência a classe de empresa:
        public int CompanyId { get; set; }
        public Company Company_ { get; set; }

        // Quantidade de produtos ao criar o cadastro de estoque:
        public int StartingQuantity { get; set; }   

        // Quantidade total inicial + entradas + estorno - saídas.
        public  int TotalQuantity { get; set; } 

      

    }
}
