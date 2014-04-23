using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2_projekt.models;

namespace p2_projekt.controllers
{
    public static class memberInfoController
    {
        public static void validateUser(User u)
        {
            if(u is Member)
            {
                Member m = (u as Member);
                var test = Utilities.lobopDB.Read<User>(
                    x => {
                        if (x is Member)
                            return (x as Member) == m;

                        return false;
                    }
                    );
                if(test != null)
                {
                    throw new ArgumentException("Medlem med dette medlemsnummer eksistere allerede.");
                }
            }
            if(u is HarbourMaster)
            {
                HarbourMaster h = (u as HarbourMaster);
                var test = Utilities.lobopDB.Read<User>(
                    x =>
                    {
                        if (x is HarbourMaster)
                            return (x as HarbourMaster) == h;

                        return false;
                    }
                    );
                if (test != null)
                {
                    throw new ArgumentException("Admin med dette brugernavn eksistere allerede.");
                }
            }
            if(u is Guest)
            {
                Guest g = (u as Guest);
                var test = Utilities.lobopDB.Read<User>(
                    x => {
                        if (x is Guest)
                            return (x as Guest) == g;

                        return false;
                    }
                    );
                if(test != null)
                {
                    throw new ArgumentException("Guest med dette id eksistere allerede.");
                }
            }
        }
    }
}
