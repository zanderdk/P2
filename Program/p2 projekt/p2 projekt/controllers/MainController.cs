using System.Collections.Generic;
using System.Linq;
using p2_projekt.WPF;
using p2_projekt.models;

namespace p2_projekt.controllers
{
    public static class MainController
    {
        public static Main Main;

        public static void SelectUser(User user)
        {
            Main.SelectUser(user);
        }
    }
}
