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
using p2_projekt.Enums;

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


            DALController us = Utilities.LobopDB;
            
            if(File.Exists(database_path) == false )
            {
            new DatabaseCreation().CreateDataset(us, 50);
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
