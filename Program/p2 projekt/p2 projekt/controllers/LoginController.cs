using p2_projekt.models;
using p2_projekt.WPF;
using System.Windows;

namespace p2_projekt.controllers
{
    public class LoginController
    {
        private enum ValidateResult { Succes, WrongPassword, UserNotFound }
        
        public bool Validate(string username, string password)
        {
            User u = FindUserByUsername(username);
            ILoginable loginable = u as ILoginable;
            bool shouldClose = false;
            if (u != null)
            {
                
                if (password == loginable.Password)
                {
                    shouldClose = true;
                    ValidateHandler(ValidateResult.Succes, u);
                }
                else
                {
                    ValidateHandler(ValidateResult.WrongPassword, u);
                }

            }
            else
            {
                ValidateHandler(ValidateResult.UserNotFound, u);
            }

            return shouldClose;
        }

        public bool Validate(string userid)
        {
            DALController userController = Utilities.LobopDB;
            User u = userController.Read<User>(x => x.UserId.ToString() == userid);
            bool shouldClose = false;
            if (u != null)
            {
                ValidateHandler(ValidateResult.Succes, u);
                shouldClose = true;
            }
            return shouldClose;
        }



        private User FindUserByUsername(string username)
        {
            DALController userController = Utilities.LobopDB;
            User u = userController.Read<User>(x =>
            {
                var y = x as ILoginable;
                return (y != null && y.Username == username);
            });

            return u;
        }

        private void ValidateHandler(ValidateResult result, User user)
        {
            switch (result){
                case ValidateResult.Succes:
                    new FunctionContainer(user).Show();
                    break;
                case  ValidateResult.WrongPassword:
                    MessageBox.Show("Forkert password.");
                    break;
                case ValidateResult.UserNotFound:
                    MessageBox.Show("Bruger ikke fundet.");
                    break;
            }
        }
    }

    
}
