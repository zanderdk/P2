using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using p2_projekt.WPF;
using p2_projekt.models;

namespace p2_projekt
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            System.Windows.Application app = new System.Windows.Application();

            HarbourMaster har = new HarbourMaster();
            har.Permissions = new Permissions();
            


            

            //TODO
            using (var db = new LobopContext())
            {
                Member alice = new Member("Alice", new System.Device.Location.CivicAddress());
                alice.Birthday = new DateTime(1,1,1);
                if (db.Members.Find(alice.PersonId) == null) { 
                    db.Members.Add(alice);
                }

                var query = from b in db.Members
                            select b;

                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                

                db.SaveChanges();
            }

            app.Run(new main(har));
        }

    }
}
