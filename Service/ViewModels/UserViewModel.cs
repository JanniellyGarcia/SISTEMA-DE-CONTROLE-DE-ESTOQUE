using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    public class UserViewModel
    {
        [JsonPropertyName("Id")]
        public string Id { get; set; }

        [JsonPropertyName("Nome")]
        public string Name { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Senha")]
        public string Password { get; set; }

        [JsonPropertyName("Cargo")]
        public string Occupation { get; set; }

       
    }
}
