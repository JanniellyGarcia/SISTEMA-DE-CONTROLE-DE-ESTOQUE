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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SqlContext context) : base(context)
        {

        }
        public User GetAllAuthentication(string emailAut, string passwordAut)
        {
            var obj = CurrentSet
                          .Where(x => x.Email == emailAut && x.Password == passwordAut)
                          .FirstOrDefault();
            return obj;
        }

        public User GetById(int Id)
        {
            var obj = CurrentSet
                .Where(x => x.Id == Id) 
                .FirstOrDefault();
            return obj;
        }

        public IEnumerable<User> GetUser()
        {
            var obj = CurrentSet
                .ToList();
            return obj;
        }
    }
}
