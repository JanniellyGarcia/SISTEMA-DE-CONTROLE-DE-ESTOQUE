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
        // Chamada para o método de listas todos os usuários.
        IEnumerable<User> GetUser();
        
        // Buscar o usuário com o id indicado.
        User GetById(int Id);

        // Chamada para o método que recupera o usuário pelo seu email e sua senha.
        User GetAllAuthentication(string emailAut, string passwordAut);

    }
}
