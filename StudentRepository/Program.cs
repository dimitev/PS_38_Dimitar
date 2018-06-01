using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    class Program
    {
        static void Main(string[] args)
        {
            String fnom;
            String cer;
            Student stud;
            StudentData.addTestStudents();
            Console.WriteLine("StudentRepository");
            Console.WriteLine("F.Nom to print");
            fnom = Console.ReadLine();
            stud = StudentData.IsThereStudent(fnom);
            cer = StudentData.PrepareCertificate(ref stud);
            Console.WriteLine(cer);
            StudentData.SaveCertificate(cer);
        }
    }
}
