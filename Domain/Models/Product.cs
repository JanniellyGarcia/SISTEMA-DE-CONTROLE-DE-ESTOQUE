using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    // Model de Produto.
    public class Product : BaseEntity
    {

        // Chave primária de produto.
        public int IdProduct { get; set; }   

        //Nome do produto.
        public string NameProduct { get; set; }

    }
}
