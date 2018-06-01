using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {

        static void Main(string[] args)
        {
            //UserData user = new UserData();
            RightsGranted.SetUserPermisions();
            User user = null;
            Console.WriteLine("Username: ");
            String username = Console.ReadLine();
            Console.WriteLine("Password: ");
            String password = Console.ReadLine();


            LoginValidation vali = new LoginValidation(username, password, ConsoleShowErr);

            if (vali.ValidateUserInput(ref user))
            {
                Console.Clear();
                Console.WriteLine("Username: " + user.userName);
                Console.WriteLine("Password: " + user.password);
                Console.WriteLine("Faculty Number: " + user.facultyNumber);

                switch (user.role)
                {
                    case UserRole.ANONYMOUS: Console.WriteLine("Role: " + UserRole.ANONYMOUS);
                        break;
                    case UserRole.ADMIN: Console.WriteLine("Role: " + UserRole.ADMIN);
                        AdminMenu();
                        break;
                    case UserRole.INSPECTOR: Console.WriteLine("Role: " + UserRole.INSPECTOR);
                        break;
                    case UserRole.PROFESSOR:
                        Console.WriteLine("Role: " + UserRole.PROFESSOR);
                        break;
                    case UserRole.STUDENT:
                        Console.WriteLine("Role: " + UserRole.STUDENT);
                        break;
                }
            }
            else
            {
                Console.WriteLine(vali.Error);
                Console.ReadLine();
            }
        }
        static public void ConsoleShowErr(string errorMsg)
        {
            Console.WriteLine("!!!" + errorMsg + "!!!");
        }
        public static void AdminMenu()
        {
            String input;
            int ans;
            int flag = 0;
            do
            {
                Console.WriteLine("1:EXIT");
                Console.WriteLine("2:Change user role");
                Console.WriteLine("3:Change user activity");
                Console.WriteLine("4:All users");
                Console.WriteLine("5:View log");
                Console.WriteLine("6:Show recent activity");
                Console.WriteLine("Choose option ");
                do
                {
                    input = Console.ReadLine();
                    ans = Convert.ToInt32(input);
                    flag = 0;
                    if(ans==2||ans==3)
                    {
                        if(!RightsGranted.Rights[UserRole.ADMIN].Contains(RoleRights.CanEditStudents))
                        {
                            Console.WriteLine("no access");
                            flag=1;
                        }
                    }
                    if (ans == 5||ans==6)
                    {
                        if (!RightsGranted.Rights[UserRole.ADMIN].Contains(RoleRights.CanSeeLogs))
                        {
                            Console.WriteLine("no access");
                            flag = 1;
                        }
                    }
                    if (ans == 8 || ans == 9)
                    {
                        if (!RightsGranted.Rights[UserRole.ADMIN].Contains(RoleRights.CanEditUsers))
                        {
                            Console.WriteLine("no access");
                            flag = 1;
                        }
                    }

                    } while (ans < 1 || ans > 6|| flag==1);

                switch (ans)
                {
                    case 2:
                        {
                            //User userToChange = UserData.getValidUser();
                            int index = UserData.getValidIndex();
                            UserRole ur;
                            Console.WriteLine("Current user role: " + UserData.TestUser[index].role);
                            Console.WriteLine("New role: ");
                            ur = UserData.ToEnum(Console.ReadLine());
                            Console.WriteLine("New role:" + ur);
                            UserData.AssignUserRole(index, ur);
                            break;
                        }
                    case 3:
                        {
                            //User userToChange = UserData.getValidUser();
                            int index = UserData.getValidIndex();
                            DateTime newUserActiveTo;
                            Console.WriteLine("Current user active to: " + UserData.TestUser[index].activeUntil);
                            Console.WriteLine("New time: ");
                            DateTime.TryParse(Console.ReadLine(), out newUserActiveTo);
                            Console.WriteLine("New time:" + newUserActiveTo);
                            UserData.SetUserActiveTo(index, newUserActiveTo);
                            break;
                        }
                    case 4:
                        {
                            Dictionary<string, int> allusers = UserData.AllUsernames();
                            //Console.WriteLine("All users "+ allusers.Count);
                            Console.Clear();
                            foreach (var currentuser in allusers)
                            {
                                Console.WriteLine(currentuser.Value + "  " + currentuser.Key);
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine(File.ReadAllText("Log.txt"));
                            Console.ReadKey();
                            break;
                        }
                    case 6:
                        {
                            String activity;
                            Console.Clear();
                            Console.WriteLine("Type in activity ");
                            activity = Console.ReadLine();
                            Console.WriteLine("Current activities");
                            Logger.GetCurrentSessionActivies(activity);
                            Console.ReadKey();
                            break;
                        }
                }
            } while (ans != 1);
        }
    }
}