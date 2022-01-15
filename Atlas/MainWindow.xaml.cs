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
using System.Data.SQLite;

namespace Atlas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string dbConnectionString = @"Data Source = AtlasDB.db;Version=3;";
        public MainWindow()
        {

            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            var Username = txtUsername.Text;
            var Password = txtPassword.Password;     

            try
            {
                sqliteCon.Open();
                string Query = "select * from users where user='" + Username + "' and pass='" + Password + "' ";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();
                SQLiteDataReader dr = createCommand.ExecuteReader();
                

                int count = 0;
                while (dr.Read())
                {
                    count++;

                }
                if (count == 1)
                {
                    SecondWindow secondWindow = new SecondWindow();
                    secondWindow.Show();
                    sqliteCon.Close();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("Who r u!?");
                }
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
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
