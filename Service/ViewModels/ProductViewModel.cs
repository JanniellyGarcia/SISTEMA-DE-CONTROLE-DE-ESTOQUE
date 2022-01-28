using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    // Representação da model de produto.
    public class ProductViewModel
    {
        [JsonPropertyName("IdProduct")]
        public int IdProduct { get; set; }

        [JsonPropertyName("NameProduct")]
        public string NameProduct { get; set; }

    }
}
