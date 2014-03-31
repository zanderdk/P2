using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using p2_projekt.WPF;
using p2_projekt.models;
using System.IO;

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
            string root_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            AppDomain.CurrentDomain.SetData("DataDirectory", root_path);

            
            
            //TODO
           
            using (var db = new LobopContext())
            {
                Member alice = new Member("Alice", new System.Device.Location.CivicAddress());
                alice.Birthday = new DateTime(2013,1,1);
                alice.PersonId = 4;
                db.Members.Add(alice);
                db.SaveChanges();

                var query = from b in db.Members
                            select b;

                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                

                
            }
            
            app.Run(new ChipRequester());
        }

    }
}
