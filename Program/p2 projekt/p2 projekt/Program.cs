﻿using System;
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
            string database_path = root_path + @"\lobopDB.mdf";

            AppDomain.CurrentDomain.SetData("DataDirectory", root_path);


            DALController us = Utilities.lobopDB;
            
            if(File.Exists(database_path) == false )
            {
            new DatabaseCreation().CreateDataset(us, 50);
            }

            


            BoatSpace bs = new WaterSpace(10.0, 10.0) { Info = "dfgdfg" };
            Boat b = new Boat() { Name = "test Ship", BoatSpace = bs, RegistrationNumber = "fdsf" };
            Travel travel = new Travel(new DateTime(2008, 1, 1), new DateTime(2001, 1, 1));
            Member alice = new Member("Christian", new System.Device.Location.CivicAddress("bistands crib no 1", "", "", "kbh", "Denmark", "", "fuck", "")) { Password = "test", Birthday = new DateTime(2000, 1, 1) };
            alice.Permission = new Permission() { MemberInfo = PermissionLevel.Write, Search = PermissionLevel.Write, ChangePersonalInfo = PermissionLevel.Write };
            //alice.Travels.Add(travel);
            //Permission2 p2 = new Permission2();
            //p2.MyProperty = "hej";
            //alice.Permission2 = p2;
            alice.RegistrationDate = new DateTime(2013, 1, 1);
            alice.Boats.Add(b);
            alice.Email = "Christian_gay@royal.danishKingdom.dk";



            //var users = us.ReadAll<User>(x => true);

            //foreach (var item in users)
            //{
            //    Console.WriteLine((item as Member).Password + "  " + (item as Member).MembershipNumber);
            //}

            //using (var db1 = new LobopContext())
            //{

            //    var prut = db1.Users.Include(x => x.Permission).ToList();

            //    foreach (var item in prut)
            //    {
            //        Console.WriteLine(item.Permission.MemberInfo);
            //    }
            //}



            //Console.WriteLine(per.MemberInfo);
            var test = us.ReadAll<User>(x => true);
            foreach(var item in test)
            {
                
                Member m = item as Member;
                if (m != null)
                {
                    Console.WriteLine(m.MembershipNumber + m.Password);
                }
            }

            
            app.Run(new ChipRequester());
        }

    }
}
