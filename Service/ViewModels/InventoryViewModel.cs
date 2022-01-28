using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    // Representa a model de estoque.
    public class InventoryViewModel
    {
        // Indentificador de Estoque:
        [JsonPropertyName("IdInventory")]
        public int IdInventory { get; set; }


        // Referência a classe de porduto:
        [JsonPropertyName("ProductId")]
        public int ProductId { get; set; }
        [JsonPropertyName("Product_")]
        public Product Product_ { get; set; }


        // Referência a classe de empresa:
        [JsonPropertyName("CompanyId")]
        public int CompanyId { get; set; }
        [JsonPropertyName("Company_")]
        public Company Company_ { get; set; }


        // Quantidade de produtos ao criar o cadastro de estoque:
        [JsonPropertyName("StartingQuantity")]
        public int StartingQuantity { get; set; }


        // Quantidade total inicial + entradas + estorno - saídas.
        [JsonPropertyName("TotalQuantity")]
        public int TotalQuantity { get; set; }


 
    }
}
