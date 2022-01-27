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
        IEnumerable<UserViewModel> GetUser();
        User GetUserForLogin(string email, string senha);
    }
}
