using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using p2_projekt.WPF;
using p2_projekt.models;
using System.IO;
using System.Data.Entity;

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

            Member alice = new Member("Alice", new System.Device.Location.CivicAddress());
            alice.UserId = 257;
            alice.Birthday = new DateTime(2013, 1, 1);

            UserController userController = new UserController(new Utilities.Database());

            userController.Add(alice);
            
            //TODO
            //Member alice = new Member("alice",new System.Device.Location.CivicAddress());
            //alice.UserId = 1;
            //alice.Birthday = new DateTime(2013, 1, 1);
            //Utilities.Database.Action( (LobopContext db) => {
            //    if(db.Members.Find(alice.UserId) == null) 
            //        db.Members.Add(alice);
                
            //    db.SaveChanges();

            //    foreach (var item in db.Members) Console.WriteLine(item.UserId);
            //});

            
            app.Run(new ChipRequester());
        }

    }
}
