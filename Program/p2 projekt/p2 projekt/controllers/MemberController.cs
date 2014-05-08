﻿using p2_projekt.Enums;
using p2_projekt.models;

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
                us.Add(_user);
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
    }
}