using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2_projekt.WPF;
using p2_projekt.models;

namespace p2_projekt.controllers
{
    public static class MainController
    {
        public static Main main;

        public static void selectUser(User user)
        {
            main.selectUser(user);
        }
    }
}
