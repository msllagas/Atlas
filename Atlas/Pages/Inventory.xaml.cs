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


        //private void inventory_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    delete_btn_Click(sender, e);
        //}

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
            var emp = 0;
            inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products").ToList();
            //using (DataContext context = new DataContext())
            //{
            //    products = context.Products.ToList();

            //    if (products.Count > 0)
            //        inventory_list.ItemsSource = products;
            //}
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {

           //MessageBox.Show(category.Content.ToString());            
            if (!String.IsNullOrEmpty(SearchField.Text) && !String.IsNullOrEmpty(Category_Cmbox.Text))
            {
                using (DataContext context = new DataContext())
                {

                    var input = SearchField.Text;
                    var category = Category_Cmbox.SelectedItem.ToString();

                    inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where Category = {0} AND ProductName = {1}", category, input).ToList();
                    //inventory_list.ItemsSource = context.Products.FromSqlInterpolated($"Select * from Products where Category = {category} AND ProductName = {input}").ToList();
                    
                }
            }

        }

        private void Category_Cmbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem category = (ComboBoxItem)Category_Cmbox.SelectedItem;
            string strCategory = category.Content.ToString();
            var db = new DataContext();
            

            inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products where Category = {0}", strCategory).ToList();
            
        }

        private void delete_product(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                if (inventory_list.SelectedItems.Count > 0)
                {
                    
                    CSProduct delProduct = inventory_list.SelectedItem as CSProduct;

                    context.Remove(delProduct);
                    context.SaveChanges();
                    Read();
                }
                else
                    MessageBox.Show("Please select a product to be deleted!");
            }

            
        }

        private void inventory_list_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            delete_btn.IsEnabled = true;
        }
    }
}
