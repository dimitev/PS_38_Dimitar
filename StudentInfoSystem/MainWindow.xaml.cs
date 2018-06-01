using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserLogin;
using StudentRepository;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged //, INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        //OnPropertyChanged(new PropertyChangedEventArgs("Name"));//put this in the set method of a binded property
        public static User user = null;
        public static List<String> ShownFaculties { get { return _ShownFaculties; } }
        public static List<String> _ShownFaculties = new List<String> ();
        public static List<String> ShownDegree { get { return _ShownDegree; } }
        public static List<String> _ShownDegree = new List<String>();
        public static List<String> ShownSpec { get { return _ShownSpec; } }
        public static List<String> _ShownSpec = new List<String>();
        public List<string> StudStatusChoices { get; set; }
        public Student Current { get { return _current; }set{ _current = value; } }
        public Student _current;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            
            StudentData.addTestStudents();
           
            if (user == null)
            {
                Login Log1 = new Login();
                this.Close();
                Log1.Show();
            }
            else
            {
                addFaculties();
                addDegree();
                FillStudStatusChoices();
                InitializeComponent();
                currentUser.Content = "Current user: " + user.userName + "  as:  " + user.role.ToString();
            }

        }
        private void FillStudStatusChoices()
        {

            StudStatusChoices = new List<string>();
            using (IDbConnection connection = new
            SqlConnection(Properties.Settings.Default.DbConnect))
            {
                string sqlquery =
                @"SELECT StatusDescr FROM StudStatus";
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
                    StudStatusChoices.Add(s);
                    notEndOfResult = reader.Read();
                }
            }
        }

public void addDegree()
        {
            _ShownDegree.Clear();
            _ShownDegree.Add("batchelor");
            _ShownDegree.Add("master");

        }
        public void addFaculties()
        {
            _ShownFaculties.Clear();
            _ShownFaculties.Add("FKST");
            _ShownFaculties.Add("MF");
            _ShownFaculties.Add("MTF");
        }
        public void UpdateSpec(object sender, SelectionChangedEventArgs e)
        {
            UpdateSpec();
        }
        public void UpdateSpec()
        {
            if (cboxFaculty.SelectedItem.ToString() == "FKST")
            {
                _ShownSpec.Clear();
                _ShownSpec.Add("ITI");
                _ShownSpec.Add("KSI");
            }
            else if (cboxFaculty.SelectedItem.ToString() == "MF")
            {
                _ShownSpec.Clear();
                _ShownSpec.Add("ID");
                _ShownSpec.Add("---");
            }
            else if (cboxFaculty.SelectedItem.ToString() == "MTF")
            {
                _ShownSpec.Clear();
                _ShownSpec.Add("ne gi");
                _ShownSpec.Add("znam");
            }
            else
            {
                _ShownSpec.Clear();
                _ShownSpec.Add("If-a");
                _ShownSpec.Add("Se ebava");
            }
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("ShownSpec"));
                PropertyChanged(this, new PropertyChangedEventArgs("Current.Speciality"));
            }

        }
        public static void Clear(FrameworkElement toClean)
        {
            if (toClean is GroupBox)
            {
                GroupBox gb = toClean as GroupBox;
                Clear(gb.Content as FrameworkElement);
                return;
            }
            if (toClean is StackPanel)
            {
                foreach (var t in (toClean as StackPanel).Children)
                {
                    Clear(t as FrameworkElement);
                }
                return;
            }
            if (toClean is TextBox)
            {
                (toClean as TextBox).Text = "";
                return;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear(gbUser as FrameworkElement);
            Clear(gbUniInfo as FrameworkElement);
        }
        public static void Active(FrameworkElement toChange,Boolean state)//unused, takes an graphical element and disables/enables the content
        {
            if (toChange is GroupBox)
            {
                GroupBox gb = toChange as GroupBox;
                Active(gb.Content as FrameworkElement,state);
                return;
            }
            if (toChange is StackPanel)
            {
                foreach (var t in (toChange as StackPanel).Children)
                {
                    Active(t as FrameworkElement, state);
                }
                return;
            }
            if (toChange is TextBox)
            {
                (toChange as TextBox).IsEnabled= state;
                return;
            }
            if (toChange is Label)
            {
                (toChange as Label).IsEnabled = state;
                return;
            }
        }
        public void DisplayInfo(Student s)
        {
            _current = new Student(s.Name,s.surname,s.familyname,s.Faculty,s.Speciality,s.Degree,s.Status,s.facultyNumber,s.lastAuthentication,s.Year,s.Mass,s.Group);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Current"));

            /* txtName.Text = s.name;
            txtSurname.Text = s.surname;
            txtFamilyname.Text = s.familyname;
            txtDegree.Text = s.Degree;
            cboxFaculty.Text = s.Faculty;
            txtGroup.Text = s.Group.ToString();
            txtMass.Text = s.Mass.ToString();
            cboxSpeciality.Text = s.Speciality;
            txtFnum.Text = s.facultyNumber;
            txtYear.Text = s.Year.ToString();*/
        }
        public void ActivateInfo()
        {
            gbUser.IsEnabled = false;
            gbUniInfo.IsEnabled = false;
        }
        public void DeactivateInfo()
        {
            gbUser.IsEnabled = false;
            gbUniInfo.IsEnabled = false;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.user = new User("", "", "",DateTime.MinValue,DateTime.MaxValue,UserRole.ANONYMOUS);
            Login Log1 = new Login();
            Log1.Show();
            this.Close();
        }

        private void btnClear_Search(object sender, RoutedEventArgs e)
        {
            FnomSearch Fn = new FnomSearch();
            Fn.Show();
            this.Close();
        }
        private void btnPerm_Click(object sender, RoutedEventArgs e)
        {

        }
                /*public void OnPropertyChanged(string name)
        {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
        handler(this, new PropertyChangedEventArgs(name));
        }
        }*/
    }
}
