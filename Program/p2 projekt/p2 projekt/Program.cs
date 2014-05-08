﻿using System;
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


            
            string rootPath = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            string databasePath = rootPath + @"\lobopDB.mdf";

            AppDomain.CurrentDomain.SetData("DataDirectory", rootPath);


            DALController us = Utilities.LobopDB;
            
            if(File.Exists(databasePath) == false )
            {
            new DatabaseCreation().CreateDataset(us, 20);
            }

            
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
