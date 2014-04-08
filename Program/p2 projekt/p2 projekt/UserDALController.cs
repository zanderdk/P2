using p2_projekt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt
{
    public class UserController
    {
        IUserDAL _iUserDal;

        public UserController(IUserDAL userDAL)
        {
            _iUserDal = userDAL;
        }

        public bool Add(User user){
            bool successful = false;
            //try
            //{
                _iUserDal.Create(user);
                successful = true;
            //}
            //catch (InvalidOperationException)
            //{
            //    Console.WriteLine("could not add user");
            //}

            return successful; 
        }

        public void Remove(Member alice)
        {
            throw new NotImplementedException();
        }
    }
}
