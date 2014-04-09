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

        public void Read<TResult>(Func<TResult, bool> pre) where TResult : class
        {
            _iUserDal.Read<TResult>(pre);
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
