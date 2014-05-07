using p2_projekt.models;
using System;
using System.Collections.Generic;

namespace p2_projekt
{
    public class DALController
    {
         private readonly IDAL _iUserDal;

        public DALController(IDAL userDAL)
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
                throw;
            }

            return successful; 
        }

        public TResult Read<TResult>(Func<TResult, bool> pre) where TResult : class
        {

            return _iUserDal.Read(pre);
        }

       

        public void Update<TInput>(TInput item) where TInput : class
        {
            _iUserDal.Update(item);
        }

        public IEnumerable<TResult> ReadAll<TResult>(Func<TResult, bool> pre) where TResult : class
        {

            return _iUserDal.ReadAll(pre);
        }

        public bool Remove<TInput>(TInput item) where TInput : class
        {
            bool sucessful = false;

            try
            {
                _iUserDal.Delete(item);
                sucessful = true;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Could not remove item.");
            }
            return sucessful;
        }
    }
}
