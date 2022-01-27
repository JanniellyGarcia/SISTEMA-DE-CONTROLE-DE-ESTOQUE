using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // Interface do Repositório de Usuário.
    public interface IUserRepository
    {
        IEnumerable<User> GetUser();
        User GetById(int Id);

        User GetAllAuthentication(string emailAut, string passwordAut);

    }
}
