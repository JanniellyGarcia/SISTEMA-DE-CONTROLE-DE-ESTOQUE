using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static Domain.Models.Output;

namespace Service.ViewModels
{
    public class OutputViewModel
    {
        [JsonPropertyName("OutputInput")]
        public int IdOutput { get; set; }

        [JsonPropertyName("ProductId")]
        public int ProductId { get; set; }

        [JsonPropertyName("product")]
        public ProductViewModel product { get; set; }

        [JsonPropertyName("CompanyId")]
        public int CompanyId { get; set; }

        [JsonPropertyName("company")]
        public Company company { get; set; }

        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("OutputStatus")]
        public OutputType OutputStatus { get; set; }


    }
}
