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
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Security;

namespace Atlas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        public MainWindow()
        {

            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var Username = txtUsername.Text;
            var Password = txtPassword.Password;

            using (UserDataContext context = new UserDataContext())
            {
                bool userfound = context.Users.Any(user => user.user == Username && user.pass == Password);
                if (userfound)
                {
                    // MessageBox.Show("Hello!");
                    SecondWindow secondWindow = new SecondWindow();
                    secondWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Who are u?!");
                }
            }

         
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

      
    }
}
