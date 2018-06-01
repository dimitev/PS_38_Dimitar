using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class RightsGranted
    {
        public static Dictionary<UserRole, List<RoleRights>> Rights = new Dictionary<UserRole, List<RoleRights>>();
        public static void SetUserPermisions()
        {
            Rights.Clear();
            for(UserRole u=0;u<=UserRole.STUDENT;u++)
            {
                List<RoleRights> r = new List<RoleRights>();
                Console.WriteLine(u+"\n can edit users:(y/n) ");
                if (Console.ReadLine() == "y") r.Add(RoleRights.CanEditUsers);
                Console.WriteLine(u + "\n can see logs:(y/n) ");
                if (Console.ReadLine() == "y") r.Add(RoleRights.CanSeeLogs);
                Console.WriteLine(u + "\n can edit students:(y/n) ");
                if (Console.ReadLine() == "y") r.Add(RoleRights.CanEditStudents);
                Rights[u] = r;
            }
        }
    }
}
