using p2_projekt.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt
{
    public static class Utilities
    {

        public class Database : IUserDAL
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

            public bool Read(User user)
            {
                throw new NotImplementedException();
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
