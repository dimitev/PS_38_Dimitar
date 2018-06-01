using StudentRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UserLogin;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for Intern.xaml
    /// </summary>
    public partial class Intern : Window
    {
        //public List<string> StudIntern { get; set; }
        public Student CurrentStudent { get => student; set => student = value; }
        private Student student;
        public Intern(Student s)
        {
            CurrentStudent = s;
            this.DataContext = this;
            InitializeComponent();
            FillStudIntern();
        }
        private void FillStudIntern()
        {

            //StudIntern = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                //string fnom = "121215091";//CurrentStudent.Fnom;
                string sqlquery = @"SELECT InternEntry FROM InternList where Id=" + CurrentStudent.Fnom;
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
                while (notEndOfResult)

                {
                    string s = reader.GetString(0);
                    // StudIntern.Add(s);
                    InternEntry.Text = s;
                    notEndOfResult = reader.Read();
                }
            }
        }
        private void add_Click_1(object sender, RoutedEventArgs e)
        {
            using (IDbConnection connection = new SqlConnection(Properties.Settings.Default.DbConnect))
            {
                //string fnom = "121215091";//CurrentStudent.Fnom;
                string sqlquery = @"INsert into InternList(Id,InternEntry)  values(" + CurrentStudent.Fnom + ",'" + txtInt.Text + "');";
                IDbCommand command = new SqlCommand();
                command.Connection = connection;
                connection.Open();
                command.CommandText = sqlquery;
                IDataReader reader = command.ExecuteReader();
                bool notEndOfResult;
                notEndOfResult = reader.Read();
            }
        }
    }
}
