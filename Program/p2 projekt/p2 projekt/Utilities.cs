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

        public class Database : IUserDAL
        {
            public LobopContext _context;


            public LobopContext lists()
            {
                return _context;
            }

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

            public void Create(User user)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            public void Delete(User user)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            public bool Update(User user)
            {
                throw new NotImplementedException();
            }

            public void Read<TResult>(Func<TResult,bool> predicate) where TResult: class
            {    
                Type lobobContextType = typeof(LobopContext);
                PropertyInfo[] fields = lobobContextType.GetProperties();
                bool tableFound = false;
                Type DBsetType = typeof(DbSet<TResult>);
                
                foreach (PropertyInfo f in fields)
                {
                    if (DBsetType == f.PropertyType) tableFound = true;
                }

                if (tableFound)
                {
                    string dbSetTarget = string.Empty;
                    foreach (var item in fields)
                    {
                        if (item.ToString().Contains(DBsetType.ToString()))
                        {
                            dbSetTarget = item.ToString().Split(' ')[1];
                        }
                            
                            
                            
                    }
                    DbSet<TResult> dbSet = (DbSet<TResult>) lobobContextType.GetProperty(dbSetTarget).GetValue(_context, null);
                    
                    foreach (var item in dbSet.Where(predicate))
                    {
                        Console.WriteLine(item + "----------------------------");
                    }
                    
                }
                else
                {
                    throw new KeyNotFoundException("table ikke fundet");
                }
            }
        }
        
        public static int GetNextMembershipNumber()
        {
            using (var db = new LobopContext())
            {
                return db.Users.OfType<Member>().Max(m => m.MembershipNumber) + 1;
                //return db.Members.Max(m => m.MembershipNumber) + 1;
            }
        }
    }
}
