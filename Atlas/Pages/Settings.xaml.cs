using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        string dbConnectionString = @"Data Source = AtlasDB.db;Version=3;";
        public object Appication { get; private set; }

        public Settings()
        {
            InitializeComponent();
        }

        private void btnLogout_click(object sender, RoutedEventArgs e)
        {
            var w = Application.Current.Windows[0];
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            w.Close();
           
        }
        private void btnSave_click(object sender, RoutedEventArgs e)
        {
           
            SQLiteConnection sqliteCon = new SQLiteConnection(dbConnectionString);
            var Username = txtUserEdit.Text;
            var Password = txtPassEdit.Password;
            //var Something = "1";
            try
            {
                sqliteCon.Open();
                string Query = "update users set user='" + Username + "', pass='" + Password + "' where id=1";
                SQLiteCommand createCommand = new SQLiteCommand(Query, sqliteCon);
                createCommand.ExecuteNonQuery();
                MessageBox.Show("Updated!");
                sqliteCon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
