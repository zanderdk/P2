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

        static public int GetNextMemberShipNumber()
        {
            DALController dal = Utilities.LobopDB;
            IEnumerable<User> users = dal.ReadAll<User>(x => true);
            int result = 0;
            if (users.Count() != 0)
                result = users.Max<User>(x =>
                {
                    if (x is Member) { return (x as Member).MembershipNumber; }
                    return 0;
                });

            return result + 1;
        }
    }
}
