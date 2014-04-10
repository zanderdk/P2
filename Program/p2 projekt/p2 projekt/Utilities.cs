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
            private LobopContext _context;

            public Database()
            {
                _context = new LobopContext();  
            }

            public static void AddUser(User user, LobopContext context)
            {
                Action(db =>
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }, context);
            }

            public static void AddUser(User user)
            {
                LobopContext context = new LobopContext();
                
                AddUser(user, context);
            }


            public static void Action(Action<LobopContext> action, LobopContext context)
            {
                if (context == null) throw new ArgumentNullException();

                using (var db = context)
                {
                    action(db);
                }
            }

            public static void Action(Action<LobopContext> action)
            {
                Action(action, new LobopContext());
            }

            public void Create<TInput>(TInput item) where TInput : class
            {
                DbSet<TInput> dbSet = VerifyTable<TInput>();

                if (dbSet == null) throw new KeyNotFoundException("table ikke fundet");

                dbSet.Add(item);
                _context.SaveChanges();
            }

            public void Delete<TInput>(TInput item) where TInput : class
            {
                DbSet<TInput> dbSet = VerifyTable<TInput>();

                if (dbSet == null) throw new KeyNotFoundException("table ikke fundet");
                dbSet.Remove(item);
                _context.SaveChanges();
            }

            public void Update<TInput>(TInput item) where TInput : class
            {
                DbSet<TInput> dbSet = VerifyTable<TInput>();

                if (dbSet == null) throw new KeyNotFoundException("table ikke fundet");

                dbSet.Attach(item);
                var entry = _context.Entry<TInput>(item);
                entry.State = EntityState.Modified;

                _context.SaveChanges();
               
            }

            private DbSet<T> VerifyTable<T>() where T : class
            {
                Type lobobContextType = typeof(LobopContext);
                PropertyInfo[] fields = lobobContextType.GetProperties();
                Type DBsetType = typeof(DbSet<T>);
                string dbSetTarget = string.Empty;

                foreach (PropertyInfo item in fields)
                {
                    if (DBsetType == item.PropertyType)
                    {
                        // table found
                        dbSetTarget = item.ToString().Split(' ')[1];
                        DbSet<T> dbSet = (DbSet<T>)lobobContextType.GetProperty(dbSetTarget).GetValue(_context, null);
                        return dbSet;
                    }
                }
                // table of type not found
                return null;
            }

            public TResult Read<TResult>(Func<TResult,bool> predicate) where TResult: class
            {
                DbSet<TResult> dbSet = VerifyTable<TResult>();

                if (dbSet == null) throw new KeyNotFoundException("table ikke fundet");

                return dbSet.FirstOrDefault(predicate);
            }

            public IEnumerable<TResult> ReadAll<TResult>(Func<TResult, bool> predicate) where TResult : class
            {
                DbSet<TResult> dbSet = VerifyTable<TResult>();

                if (dbSet == null) throw new KeyNotFoundException("table ikke fundet");

                return dbSet.Where(predicate);
            }
            public int GetNextMembershipNumber()
            {
                return 0;
            }
        }
    }
}
