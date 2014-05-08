using System;
using System.Collections.Generic;

namespace p2_projekt
{
    public interface IDAL
    {
        void Create<TInput>(TInput item) where TInput : class;
        void Delete<TInput>(TInput item) where TInput : class;
        void Update<TInput>(TInput item) where TInput : class;
        TResult Read<TResult>(Func<TResult, bool> predicate) where TResult : class;
        IEnumerable<TResult> ReadAll<TResult>(Func<TResult, bool> predicate) where TResult : class;

        int Max<TInput>(Func<TInput, int> pred) where TInput : class;
    }
}
