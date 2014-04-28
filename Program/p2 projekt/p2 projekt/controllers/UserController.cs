using p2_projekt.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_projekt.controllers
{
    public class UserController
    {
        public int GetNextMemberShipNumber()
        {
            DALController dal = Utilities.LobopDB;
            IEnumerable<User> users = dal.ReadAll<User>(x => true);
            int result = 0;
            if(users.Count() != 0)
            result = users.Max<User>(x =>
            {
                if (x is Member) { return (x as Member).MembershipNumber; }
                return 0;
            });

            return result + 1;
        }
    }
}
