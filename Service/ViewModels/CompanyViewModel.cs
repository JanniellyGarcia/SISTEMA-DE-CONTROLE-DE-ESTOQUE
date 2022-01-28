using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    // representa a model de empresa.
    public class CompanyViewModel
    {
        [JsonPropertyName("IdCompany")]
        public string IdCompany { get; set; }

        [JsonPropertyName("NomeCompany")]
        public string NameCompany { get; set; }
    }
}
