using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    // Interface de Serviço de usuário.
    public interface IUserService
    {
        // Chamada para o método de listar os usuários.
        IEnumerable<UserViewModel> GetUser();

        // Chamada para o método de verificação de usuário.
        User GetUserForLogin(string email, string senha);
    }
}
