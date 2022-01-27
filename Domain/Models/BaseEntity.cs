using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    //Model Base (pai).
    public class BaseEntity
    {

        //Chave estrangeira de Usuário. 
        public int ModifierUserId { get; set; }
        internal User UserReference { get; set; }

        // Data e hora das atualizações nas entidades filhas.
        public DateTime DateAndTime { get; set; } = DateTime.Now;   


    }
}
