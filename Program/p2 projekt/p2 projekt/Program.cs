using System;
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
            new DatabaseCreator().CreateDataset(us, 20);
            }

            app.Run(new Standby());
        }

    }
}
