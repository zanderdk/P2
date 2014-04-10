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
            Member alice = new Member("Frederik", new System.Device.Location.CivicAddress()) { Password="test", MembershipNumber = 1337};
            //alice.Travels.Add(travel);
            alice.Birthday = new DateTime(2013, 1, 1);
            alice.RegistrationDate = new DateTime(2013,1,1);
                        
            

            Utilities.Database db = new Utilities.Database();
            UserController userController = new UserController(db);
            userController.Add<User>(alice);

            var test = userController.ReadAll<User>(x => true);

            foreach(var item in test){
                Member m = (Member) item;
                Console.WriteLine(m.MembershipNumber + m.Password);
            }

            
            
            app.Run(new ChipRequester());
        }

    }
}
