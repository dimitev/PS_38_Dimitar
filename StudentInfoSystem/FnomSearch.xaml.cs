using StudentRepository;
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
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    /// <summary>
    /// Interaction logic for FnomSearch.xaml
    /// </summary>
    public partial class FnomSearch : Window
    {
        public FnomSearch()
        {
            InitializeComponent();
            txtFNom.Focus();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            Student s=null;
            s=StudentData.IsThereStudent(txtFNom.Text);
            if(s!=null)
            {
                MainWindow Win1 = new MainWindow();
                Win1.DisplayInfo(s);
                Win1.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No Student found");
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Win1 = new MainWindow();
            Win1.Show();
            this.Close();
        }

        private void btnMarks_Click(object sender, RoutedEventArgs e)
        {
            Student s = null;
            s = StudentData.IsThereStudent(txtFNom.Text);
            if (s != null)
            {
                /* MainWindow Win1 = new MainWindow();
                 Win1.DisplayInfo(s);
                 Win1.Show();*/
                MessageBox.Show("to do");
                this.Close();
            }
            else
            {
                MessageBox.Show("No Student found");
            }
        }
    }
}
