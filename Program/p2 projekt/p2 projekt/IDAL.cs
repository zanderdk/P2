using p2_projekt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt
{
    public interface IDAL
    {
        void Create<TInput>(TInput item) where TInput : class;
        void Delete(User user);
        bool Update(User user);
        TResult Read<TResult>(Func<TResult, bool> predicate) where TResult : class;
        IEnumerable<TResult> ReadAll<TResult>(Func<TResult, bool> predicate) where TResult : class;
    }
}
