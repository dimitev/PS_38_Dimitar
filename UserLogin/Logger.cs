using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
     public class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();
        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"+ LoginValidation.CurrentUserUsername + ";"+ LoginValidation.CurrentUserRole + ";"+ activity;
            currentSessionActivities.Add(activityLine);
            File.AppendAllText("Log.txt", activityLine+'\n');

        }
        static public void GetCurrentSessionActivies(String filter)
        {
            StringBuilder sb=new StringBuilder();
            List<string> filteredActivities = (from activity in currentSessionActivities
                                               where activity.Contains(filter)
                                               select activity).ToList();
            foreach (var action in filteredActivities)
            {
                sb.Append(action);
            }
            Console.WriteLine(sb);
        }
    }
}
