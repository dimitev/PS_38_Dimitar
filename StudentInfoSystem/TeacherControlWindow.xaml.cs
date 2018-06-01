using StudentRepository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for TeacherControlWindow.xaml
    /// </summary>
    public partial class TeacherControlWindow : Window
    {
        //public static List<Student> ShownStudents = new List<Student>();
        // public IEnumerable<Student> ShownStudents { get; private set; }
        public ObservableCollection<Student> students = new ObservableCollection<Student>();
        public ObservableCollection<Student> ShownStudents { get { return students; } }
        public TeacherControlWindow()
        {
            InitializeComponent();
            updateList();
            this.DataContext=this;
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.user = new User("", "", "", DateTime.MinValue, DateTime.MaxValue, UserRole.ANONYMOUS);
            Login Log1 = new Login();
            Log1.Show();
            this.Close();
        }
        private void btnIntern(object sender, RoutedEventArgs e)
        {
            Intern In = new Intern(StudentData.IsThereStudent(((StudentList.SelectedItem)as Student ).Fnom));
           // In.CurrentStudent =;// StudentList.SelectedItem);
            In.Show();
        }
        private void updateList()
        {
            students.Clear();
            foreach (var s in StudentData.TestStudents)
            {
               if(s.facultyNumber.Contains(txtFnom.Text))
                students.Add(s);
            }
            txtFnom.Text = ShownStudents.Count.ToString();
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            updateList();
        }
    }
}
