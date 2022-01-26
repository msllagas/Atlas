using Atlas.Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.EntityFrameworkCore;

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


        private void inventory_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            delete_btn_Click(sender, e);
        }

        public DataTemplate ItemTemplate { get; set; }

        private void add_btn_click(object sender, RoutedEventArgs e)
        {
            AddInventory gotopage = new AddInventory();
            this.NavigationService.Navigate(gotopage);
        }

        private void edit_dbl_click(object sender, RoutedEventArgs e)
        {

            EditInventory gotopage = new EditInventory();
            this.NavigationService.Navigate(gotopage);
        }

        public void Read()
        {

            var db = new DataContext();

            inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products").ToList();

            //using (DataContext context = new DataContext())
            //{
            //    products = context.Products.ToList();

            //    if (products.Count > 0)
            //        inventory_list.ItemsSource = products;
            //}
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {

            delBtn(sender);

        }

        private void delBtn(object sender)
        {
            Button targetbutton = (sender as Button);

            if (targetbutton != null && targetbutton.Name == "delete_btn")
            {
                CSProduct selProduct = (CSProduct)inventory_list.SelectedItems[0];
                if (MessageBox.Show("Are you sure you want to remove " + selProduct.ProductName + " from record?", "Please Select", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {

                    using (var context = new DataContext())
                    {
                        context.Remove(selProduct);
                        context.SaveChanges();
                        MessageBox.Show("Deleted: " + selProduct.ProductName);
                        Read();
                    }
                    //string ProductN = selProduct.ProductName;
                }
                else
                {
                    MessageBox.Show("Error deleting" + selProduct.ProductName);
                    Read();
                }
            }
        }
    }
}
