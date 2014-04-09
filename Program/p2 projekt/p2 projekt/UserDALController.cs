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
         public IUserDAL _iUserDal;

        public UserController(IUserDAL userDAL)
        {
            _iUserDal = userDAL;
        }

        public bool Add(User user){
            bool successful = false;
            try
            {
                _iUserDal.Create(user);
                successful = true;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("could not add user");
            }

            return successful; 
        }

        public void ReadUser<T, T2>(Predicate<T> pre) where T2 : class
        {
            _iUserDal.Read<T, T2>(pre);
        }

        public bool Remove(Member user)
        {
            bool sucessful = false;

            try
            {
                _iUserDal.Delete(user);
                sucessful = true;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Could not remove user.");
            }
            return sucessful;
        }
    }
}
