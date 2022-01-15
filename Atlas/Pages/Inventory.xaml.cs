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

        private void add_btn_click(object sender, RoutedEventArgs e)
        {
            AddInventory gotopage = new AddInventory();
            this.NavigationService.Navigate(gotopage);
        }

        private void edit_btn_click(object sender, RoutedEventArgs e)
        {
            EditInventory gotopage = new EditInventory();
            this.NavigationService.Navigate(gotopage);
        }
    }
}
