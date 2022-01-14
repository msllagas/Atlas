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
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Page
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void inventory_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public DataTemplate ItemTemplate { get; set; }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            AddInventory pageFunction = new AddInventory();
            this.NavigationService.Navigate(pageFunction);
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            EditInventory pageFunction = new EditInventory();
            this.NavigationService.Navigate(pageFunction);
        }
    }
}
