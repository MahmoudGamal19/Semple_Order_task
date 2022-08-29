using Doman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessInterface
{
    public interface IUser
    {
        public bool Find_Email(string email);
        public User  Login(User user);
        public User Register(User user);
    }
}
