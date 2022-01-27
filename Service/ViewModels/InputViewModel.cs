using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class InputViewModel
    {
        [JsonPropertyName("IdInput")]
        public int IdInput { get; set; }


        [JsonPropertyName("ReferenceIdProduct")]
        public int ReferenceIdProduct { get; set; }


        [JsonPropertyName("Product")]
        public ProductViewModel product { get; set; }


        [JsonPropertyName("ReferenceIdCompany")]
        public int ReferenceIdCompany { get; set; }


        [JsonPropertyName("Company")]
        public Company company { get; set; }

        [JsonPropertyName("Quantidade")]
        public int Quantity { get; set; }

    }
}
