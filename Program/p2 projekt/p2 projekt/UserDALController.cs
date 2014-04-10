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
         private IDAL _iUserDal;

        public UserController(IDAL userDAL)
        {
            _iUserDal = userDAL;
        }

        public bool Add<TInput>(TInput item) where TInput : class
        {
            bool successful = false;
            try
            {
                _iUserDal.Create(item);
                successful = true;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("could not add item");
            }

            return successful; 
        }

        public TResult Read<TResult>(Func<TResult, bool> pre) where TResult : class
        {

            return _iUserDal.Read<TResult>(pre);
        }

        public IEnumerable<TResult> ReadAll<TResult>(Func<TResult, bool> pre) where TResult : class
        {

            return _iUserDal.ReadAll<TResult>(pre);
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
