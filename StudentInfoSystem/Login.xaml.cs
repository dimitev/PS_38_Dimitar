using StudentRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            txtUsername.Focus();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }
        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           
            LoginValidation vali = new LoginValidation(txtUsername.Text, txtPassword.Text, ConsoleShowErr);

            if (vali.ValidateUserInput(ref MainWindow.user))
            {
                MainWindow Win1 = new MainWindow();
                Win1.Show();
                if (MainWindow.user.role==UserRole.STUDENT)
                {

                    Student st = StudentData.IsThereStudent(MainWindow.user.facultyNumber);
                    if(st!=null)
                        Win1.DisplayInfo(st);
                    Win1.btnPermisions.IsEnabled = false;
                    Win1.btnSearch.IsEnabled = false;
                    
                }
                if (MainWindow.user.role == UserRole.PROFESSOR)
                {
                    TeacherControlWindow Teach = new TeacherControlWindow();
                    Teach.Show();
                    Win1.Close();
                    this.Close();
                    
                    //Win1.btnPermisions.IsEnabled = false;
                }
                if (MainWindow.user.role == UserRole.ADMIN)
                {
                    AdminControlWindow Adm = new AdminControlWindow();
                    Adm.Show();
                    Win1.Close();
                    this.Close();

                    //Win1.btnPermisions.IsEnabled = false;
                }
                this.Close();
            }
            else
            {
                txtPassword.Text = "";
                Login.ConsoleShowErr("wrong info");
                vali = null;
            }
        }
        static public void ConsoleShowErr(string errorMsg)
        {
            MessageBox.Show(errorMsg);
        }

        /* private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
         {
             //MessageBox.Show("Closing");
             Application.Current.Shutdown();
         }*/
        protected override void OnClosing(CancelEventArgs e)
        {
            // show the message box here and collect the result

            // if you want to stop it, set e.Cancel = true
            //Application.Current.Shutdown();
            //MessageBox.Show("Closing");
            //e.Cancel = true;
        }
    }
}
