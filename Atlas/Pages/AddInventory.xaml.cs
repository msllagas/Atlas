using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddInventory.xaml
    /// </summary>
    public partial class AddInventory : Page
    {
        public AddInventory()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Inventory gotopage = new Inventory();
            this.NavigationService.Navigate(gotopage);
        }
    }
}
