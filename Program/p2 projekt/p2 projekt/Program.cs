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


            BoatSpace bs = new WaterSpace(0,10.0, 10.0) { info="dfgdfg" };
            Boat b = new Boat() { Name = "test Ship", BoatSpace = bs, registrationNumber = "fdsf" };
            Travel travel = new Travel(new DateTime(2008, 1, 1), new DateTime(2001, 1, 1));
            Member alice = new Member("Alices", new System.Device.Location.CivicAddress());
            //alice.Travels.Add(travel);
            alice.Birthday = new DateTime(2013, 1, 1);
            alice.RegistrationDate = new DateTime(2013,1,1);
            alice.Boats.Add(b);

            Utilities.Database db = new Utilities.Database();
            UserController userController = new UserController(db);
            userController.Add<User>(alice);

            //User us = userController.ReadUser("Alice");
            //Member m = (Member)us;

            IEnumerable<User> outUsers = userController.ReadAll<User>(x => x.Name.Contains( "Alice") );

            foreach (var item in outUsers)
            {
                Console.WriteLine(item.Name);
            }

            IEnumerable<Boat> allboats = userController.ReadAll<Boat>(x => true);

            foreach (var item in allboats)
            {
                Console.WriteLine(item.Name);
            }
            
            //TODO
            //Member alice = new Member("alice",new System.Device.Location.CivicAddress());
            //alice.UserId = 1;
            //alice.Birthday = new DateTime(2013, 1, 1);
            //Utilities.Database.Action( (LobopContext db) => {
            //    if(db.Members.Find(alice.UserId) == null) 
            //        db.Memb ers.Add(alice);
                
            //    db.SaveChanges();

            //    foreach (var item in db.Members) Console.WriteLine(item.UserId);
            //});

            
            //app.Run(new ChipRequester());
        }

    }
}
