using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        private static List<User> testUser = new List<User>();

        public static List<User> TestUser
        {
            get
            {
                DefaultUserData();
                return testUser;
            }
            set {}
        }

        static private void DefaultUserData()
        {
            testUser.Clear();
            testUser.Add(new User("Mitaka", "123456", "121215091", DateTime.Now, DateTime.MaxValue, UserRole.ADMIN));
            testUser.Add(new User("Icaka", "123456", "121215032",DateTime.Now, DateTime.MaxValue, UserRole.STUDENT));
            testUser.Add(new User("Ivann", "123456", "121215033",DateTime.Now, DateTime.MaxValue, UserRole.PROFESSOR));           
        }

        public static User IsUserPassCorrect(String name, String pass)
        {
            /*foreach (User user in TestUser)
            {
                if (user.userName.Equals(name) && user.password.Equals(pass))
                {
                    return user;
                }
            }
            return null;*/
            return (from user in TestUser
                    where user.userName == name
                    & user.password == pass
                select user).FirstOrDefault();
        }

        static public User getValidUser()
        {
            String username;
            User userToChange = null;
            do
            {
                Console.WriteLine("Target username: ");
                username = Console.ReadLine();

            } while ((userToChange = findUser(username)) == null);
            return userToChange;
        }
        static public int getValidIndex()
        {
            int i;
            do
            {
                Console.WriteLine("Target index: ");
                i = Convert.ToInt32(Console.ReadLine());

            } while ((TestUser[i]) == null);
            return i;
        }
        public static void SetUserActiveTo(int index, DateTime activeUntil)
        {
            User userToChange = TestUser[index];//findUser(username);
            userToChange.activeUntil = activeUntil;
            Console.WriteLine("Date change successful");
            Logger.LogActivity("Промяна на активност на " + TestUser[index].userName); //в SetUserActiveTo
        }

        public static void AssignUserRole(int index, UserRole role)
        {
            User userToChange = TestUser[index];// findUser(username);
            userToChange.role = role;
            Console.WriteLine("Role change successful");
            Logger.LogActivity("Промяна на роля на " + TestUser[index].userName); //в AssignUserRole
        }

        private static User findUser(string username)
        {
            foreach (var user in testUser)
            {
                if(user.userName == username)
                {
                    return user;
                }
            }

            return null;
        }
        public static UserRole ToEnum(string text)
        {
            text = text.ToUpper();
            switch (text)
            {
                case "ANONYMOUS":
                case "0":
                default:
                    return UserRole.ANONYMOUS;
                case "ADMIN":
                case "1":
                    return UserRole.ADMIN;
                case "INSPECTOR":
                case "2":
                    return UserRole.INSPECTOR;
                case "PROFESSOR":
                case "3":
                    return UserRole.PROFESSOR;
                case "STUDENT":
                case "4":
                    return UserRole.STUDENT;
            }
        }
        static public Dictionary<string,int> AllUsernames()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            //Console.WriteLine("All users " + TestUser.Count);
            for (int i = 0; i < TestUser.Count; i++)
            {
                result.Add(TestUser[i].userName, i);
            }
            return result;
        }
        
    }
}
