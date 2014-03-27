using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using p2_projekt.WPF;

namespace p2_projekt
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            System.Windows.Application app = new System.Windows.Application();
            app.Run(new MainWindow());
        }

    }
}
