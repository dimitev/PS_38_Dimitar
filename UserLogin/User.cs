using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public String userName;
        public String password;
        public String facultyNumber;
        public DateTime created;
        public DateTime? activeUntil;
        public UserRole role;
        public string UserName { get { return userName; } }
        public string FNom { get { return facultyNumber; } }
        public string UserRole { get { return role.ToString(); } }
        public System.Int32 UserId { get; set; }

        public User(String name, String pass, String facNum, DateTime created, DateTime activeUntil, UserRole rol)
        {
            this.userName = name;
            this.password = pass;
            this.facultyNumber = facNum;
            this.created = created;
            this.activeUntil = activeUntil;
            this.role = rol;
        }
    }
}
