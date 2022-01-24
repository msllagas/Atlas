using Atlas.Model_Classes;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for Inventory.xaml
    /// </summary>
    public partial class Inventory : Page
    {
        public List<CSProduct> products { get; private set; }

        public Inventory()
        {
            InitializeComponent();
            Read();
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

        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                products = context.Products.ToList();

                if (products.Count > 0)
                    inventory_list.ItemsSource = products;
            }
        }
    }
}
