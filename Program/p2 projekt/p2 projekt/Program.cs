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
            har.Permissions.canReadPersonalInfo = true;
            har.Permissions.canReadPersons = true;
            har.Permissions.canSearchPersons = false;
            har.Permissions.canReadPersonalInfo = true;
            har.Permissions.canWritePersons = true;

            app.Run(new main(har));

            //TODO
            //using (var db = new LobopContext())
            //{
            //    //Member alice = new Member("Alice", new System.Device.Location.CivicAddress());
            //    //alice.Birthday = DateTime.Now;
            //    //db.Members.Add(alice);
            //    //db.SaveChanges();
            //}
        }

    }
}
