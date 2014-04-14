using p2_projekt.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace p2_projekt
{
    public static class Utilities
    {

        public class Database : IDAL
        {
            public void Action<TInput>(Action<LobopContext, DbSet<TInput>> action, LobopContext context) where TInput : class
            {
                if (context == null) throw new ArgumentNullException();

                using (var db = context)
                {
                    DbSet<TInput> dbSet = VerifyTable<TInput>(db);
                    if (dbSet == null) throw new KeyNotFoundException("table ikke fundet");
                    action(db, dbSet);
                }
            }

            public void Action<TInput>(Action<LobopContext, DbSet<TInput>> action) where TInput : class
            {
                Action<TInput>(action, new LobopContext());
            }

            public int Max<TInput>(Func<TInput,int> pred) where TInput : class
            {
                int result = 0;
                Action<TInput>((db, dbSet) =>
                {
                    if(dbSet.Count() != 0)
                    result = dbSet.Max<TInput>(pred);
                });

                return result;
            }

            public void Create<TInput>(TInput item) where TInput : class
            {
                Action<TInput>((db, dbSet) =>
                {
                    dbSet.Add(item);
                    db.SaveChanges();
                });

            }

            public void Delete<TInput>(TInput item) where TInput : class
            {

                Action<TInput>((db, dbSet) =>
                {
                    dbSet.Remove(item);
                    db.SaveChanges();
                });

            }

            public void Update<TInput>(TInput item) where TInput : class
            {

                Action<TInput>((db, dbSet) =>
                {
                    dbSet.Attach(item);
                    var entry = db.Entry<TInput>(item);
                    entry.State = EntityState.Modified;
                    db.SaveChanges();
                });

            }

            private DbSet<T> VerifyTable<T>(LobopContext context) where T : class
            {
                Type lobobContextType = typeof(LobopContext);
                PropertyInfo[] properties = lobobContextType.GetProperties();
                Type DBsetType = typeof(DbSet<T>);
                string dbSetTarget = string.Empty;

                foreach (PropertyInfo item in properties)
                {
                    if (DBsetType == item.PropertyType)
                    {
                        // table found
                        dbSetTarget = item.ToString().Split(' ')[1];
                        DbSet<T> dbSet = (DbSet<T>)lobobContextType.GetProperty(dbSetTarget).GetValue(context, null);
                        return dbSet;
                    }
                }
                // table of type not found
                return null;
            }

            public TResult Read<TResult>(Func<TResult, bool> predicate) where TResult : class
            {
                TResult result = null;
                Action<TResult>((db, dbSet) =>
                {
                    result = dbSet.FirstOrDefault(predicate);
                });

                return result;
            }

            public IEnumerable<TResult> ReadAll<TResult>(Func<TResult, bool> predicate) where TResult : class
            {
                IEnumerable<TResult> result = null;
                Action<TResult>((db, dbSet) =>
                {
                    result = dbSet.Where(predicate).ToList();
                });

                return result;
            }  
        }
    }
}
