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
    /// Interaction logic for AdminControlWindow.xaml
    /// </summary>
    public partial class AdminControlWindow : Window
    {
        public ObservableCollection<User> users = new ObservableCollection<User>();
        public ObservableCollection<User> ShownUsers { get { return users; } }
        public AdminControlWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            updateList();
        }
        private void updateList()
        {
            users.Clear();
            foreach (var s in UserData.TestUser)
            {
                    users.Add(s);
            }
        }
    }
}
