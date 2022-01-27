using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    //Model de Usuário.
    public class User : BaseEntity
    {
        // Chave primária de usuário
        public int Id { get; set; } 

        // Nome do usuário.
        public string Name { get; set; }

        // email do usuário.
        public string Email { get; set; }

        //senha do login de usuário.
        public string Password { get; set; }

        // Cargo do funcionário.
        public string Occupation { get; set; }

    }
}
