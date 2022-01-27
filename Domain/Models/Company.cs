using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    //Model de Empresa.
    public class Company : BaseEntity
    {
        //Chave primária da empresa.
        public int IdCompany { get; set; }

        //Nome da empresa
        public string NameCompany { get; set; }
    }
}
