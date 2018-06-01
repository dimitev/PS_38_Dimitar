using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    public class StudentData
    {
        public static List<Student> TestStudents=new List<Student>();
        public static void addTestStudents()
        {
            TestStudents.Clear();
           TestStudents.Add(new Student("Hristo", "Hristov", "Hristov", "FKST", "KSI", "bachelor", "ongoing", "121215091", DateTime.Now, 4, 1, 32));
            TestStudents.Add(new Student("Dragan", "Draganov", "Draganov", "FKST", "KSI", "bachelor", "ongoing", "121215032", DateTime.Now, 4, 1, 38));
            TestStudents.Add(new Student("Petkan", "Petkanov", "Petkanov", "FKST", "KSI", "bachelor", "ongoing", "121215033", DateTime.Now, 4, 2, 29));
        }
        public static Student IsThereStudent(String fnom)
        {
            return (from student in TestStudents
                    where student.facultyNumber == fnom
                                 select student).FirstOrDefault();
        }
        public static String PrepareCertificate(ref Student current)
        {
            return "Declaration from " + current.Name + " " + current.surname + " " + current.familyname + "\n" + "  with f.nom: " + current.facultyNumber + " group: " + current.Group + "\n" + "stydying: " + current.Speciality + "\n";
        }
        public static void SaveCertificate(String cer)
        {
            String loc;
            Console.WriteLine("Where to save the document: ");
            loc = Console.ReadLine();
            File.WriteAllText(loc+"\\doc.txt" , cer);
        }
    }
}
