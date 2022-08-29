using Business.BusinessInterface;
using Doman;
using Doman.Model;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessImplemint
{
    public  class UserService:IUser
    {
        
        private readonly ApplicationDbContext _db;

        public UserService( ApplicationDbContext db)
        {
          
            _db= db;
        }

        public bool Find_Email(string email)
        {
            return false;
        }

        public User Login(User user)
        {
              return null;
        }

        public User Register(User user)
        {
               return null ;
        }
    }
}
