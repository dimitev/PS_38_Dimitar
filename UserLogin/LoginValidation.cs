using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        private ActionOnError errAction;

        public delegate void ActionOnError(string errorMsg);

        public static UserRole CurrentUserRole { get; private set; }
        public static string CurrentUserUsername { get; private set; }

        private String Username { get; set; }
        private String Password { get; set; }
        public String Error { get; set; }

        public LoginValidation(String name, String pass, ActionOnError errAction)
        {
            this.Username = name;
            this.Password = pass;
            this.errAction = errAction;

        }
        public Boolean ValidateUserInput(ref User user)
        {
            CurrentUserRole = UserRole.ANONYMOUS;

            Boolean emptyUserName;
            emptyUserName = Username.Equals(String.Empty);
            if (emptyUserName == true)
            {
                errAction("Username not found");
                return false;
            }

            Boolean emptyPassword;
            emptyPassword = Password.Equals(String.Empty);
            if (emptyPassword == true)
            {
                errAction("Password not found");
                return false;
            }

            if (Password.Length < 5)
            {
                errAction("Password shorter than 5 characters");
                return false;
            }
            else if (Username.Length < 5)
            {
                errAction("Username shorter than 5 characters");
                return false;
            }
            
            user = UserData.IsUserPassCorrect(this.Username, this.Password);
            if(user == null)
            {
                errAction("No user with matching info found");
                return false;
            }

            CurrentUserRole = (UserRole)user.role;
            CurrentUserUsername = user.userName;
            Logger.LogActivity("Succesful Login"); //във ValidateUserInput
            return true;
        }
    }
}
