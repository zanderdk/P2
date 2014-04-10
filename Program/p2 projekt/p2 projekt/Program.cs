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
            Member alice = new Member("Alice", new System.Device.Location.CivicAddress()) { Password="test"};
            //alice.Travels.Add(travel);
            alice.Birthday = new DateTime(2013, 1, 1);
            alice.RegistrationDate = new DateTime(2013,1,1);
            
            sophie.Travels.Add(travel2);
            sophie.Birthday = new DateTime(2008, 1, 1);
            sophie.RegistrationDate = new DateTime(2011, 1, 1);
            sophie.Boats.Add(b2);

            Utilities.Database db = new Utilities.Database();
            UserController userController = new UserController(db);
            userController.Add<User>(alice);

            
            Console.WriteLine("Før:");

            foreach (var item in userController.ReadAll<User>(x => true))
            {
                Console.WriteLine(item.Name);
            }
            var bob = userController.Read<User>(x => x.Name == "Bob");
            bob.Name = "Simon";
            userController.Update(bob);
            Console.WriteLine("Efter:");

            foreach (var item in userController.ReadAll<User>(x => true))
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

            
            app.Run(new ChipRequester());
        }

    }
}
