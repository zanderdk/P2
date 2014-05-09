using p2_projekt.Enums;
using p2_projekt.models;
using System.Collections.Generic;
using System.Linq;

namespace p2_projekt.controllers
{
    class MemberController
    {
        private readonly User _user;
        private readonly Operation _operation;
        public MemberController(User user, Operation operation)
        {
            _operation = operation;
            _user = user;
        }

        public bool SubmitChanges(string password)
        {
            DALController us = Utilities.LobopDB;

            if (_operation == Operation.Add)
            {
                Member member = _user as Member;
                if (member != null) member.Password = password;
                member.Permission = new Permission();
                member.Permission.Map = PermissionLevel.Read;
                member.Permission.PersonalInfo = PermissionLevel.Write;
                member.Permission.OtherUsers = PermissionLevel.None;
                us.Add(member as User);
            }

            else if (_operation == Operation.Edit)
            {
                if (_user is Member)
                {
                    (_user as Member).Password = password;
                }
                us.Update(_user);
            }
            return true;
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
