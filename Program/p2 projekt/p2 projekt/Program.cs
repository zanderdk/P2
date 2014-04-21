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

            string root_path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));

            AppDomain.CurrentDomain.SetData("DataDirectory", root_path);


            BoatSpace bs = new WaterSpace(10.0, 10.0) { info = "dfgdfg" };
            Boat b = new Boat() { Name = "test Ship", BoatSpace = bs, RegistrationNumber = "fdsf" };
            Travel travel = new Travel(new DateTime(2008, 1, 1), new DateTime(2001, 1, 1));
            Member alice = new Member("Christian", new System.Device.Location.CivicAddress("bistands crib no 1", "", "", "kbh", "Denmark", "", "fuck", "")) { Password = "test", Birthday = new DateTime(2000, 1, 1) };
            alice.Permission = new Permission() { MemberInfo = PermissionLevel.Write, search = PermissionLevel.Write, ChangePersonalInfo = PermissionLevel.Write };
            //alice.Travels.Add(travel);
            //Permission2 p2 = new Permission2();
            //p2.MyProperty = "hej";
            //alice.Permission2 = p2;
            alice.RegistrationDate = new DateTime(2013, 1, 1);
            alice.Boats.Add(b);
            alice.Email = "Christian_gay@royal.danishKingdom.dk";

            UserController us = new UserController(new Utilities.Database());
            us.Add<User>(alice);


            //using (var db1 = new LobopContext())
            //{

            //    var prut = db1.Users.Include(x => x.Permission).ToList();

            //    foreach (var item in prut)
            //    {
            //        Console.WriteLine(item.Permission.MemberInfo);
            //    }
            //}



            //Console.WriteLine(per.MemberInfo);

            //foreach(var item in test){
            //    Member m = (Member) item;
            //    Console.WriteLine(m.MembershipNumber + m.Password);
            //}

            
            app.Run(new ChipRequester());
        }

    }
}
