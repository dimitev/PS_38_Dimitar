using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRepository
{
    
    public class Student
    {
       /* public string Name { get { return name; } }
        public string FamName { get { return familyname; } }
        public string Fnom { get { return facultyNumber; } }*/

        public string Status { get => status; set => status = value; }
        public string Faculty { get => faculty; set => faculty = value; }
        public string Speciality { get => speciality; set => speciality = value; }
        public string Degree { get => degree; set => degree = value; }
        public int Year { get => year; set => year = value; }
        public int Mass { get => mass; set => mass = value; }
        public int Group { get => group; set => group = value; }
        public string Name { get => name; set => name = value; }
        public string FamName { get => familyname; set => familyname = value; }
        public string Fnom{ get => facultyNumber; set => facultyNumber = value; }
        public string SurName { get => surname; set => surname = value; }
        public int StudentId { get; set; }

        public String name;
        public String surname;
        public String familyname;
        public String faculty;
        public String speciality;
        public String degree;
        private String status;
        public String facultyNumber;
        public DateTime lastAuthentication;
        public int year;
        public int mass;//поток
        public int group;
        public Student(String name, String surname, String familyname, String faculty, String speciality, String degree, String status, String facultyNumber, DateTime lastAuthentication, int year, int mass, int group)
        {
            this.Name = name;
            this.surname = surname;
            this.familyname = familyname;
            this.faculty = faculty;
            this.speciality = speciality;
            this.degree = degree;
            this.Status = status;
            this.facultyNumber = facultyNumber;
            this.lastAuthentication = lastAuthentication;
            this.year = year;
            this.mass = mass;
            this.group = group;
        }
    }
}
