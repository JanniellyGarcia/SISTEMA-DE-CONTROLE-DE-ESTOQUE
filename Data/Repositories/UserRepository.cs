using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    //Repoitório de usuário.
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SqlContext context) : base(context)
        {

        }
        // Implementação do método de autenticação.
        public User GetAllAuthentication(string emailAut, string passwordAut)
        {
            var obj = CurrentSet
                          .Where(x => x.Email == emailAut && x.Password == passwordAut)
                          .FirstOrDefault();
            return obj;
        }

        // Implementação do método de buscar o usuário pelo id no banco.
        public User GetById(int Id)
        {
            var obj = CurrentSet
                .Where(x => x.Id == Id) 
                .FirstOrDefault();
            return obj;
        }

        // Implementação de método de bsucar todos os usuários existentes no banco.
        public IEnumerable<User> GetUser()
        {
            var obj = CurrentSet
                .ToList();
            return obj;
        }
    }
}
