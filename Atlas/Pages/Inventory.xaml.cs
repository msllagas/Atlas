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
        public DataTemplate ItemTemplate { get; set; }

        private void add_btn_click(object sender, RoutedEventArgs e)
        {
            AddInventory gotopage = new AddInventory();
            this.NavigationService.Navigate(gotopage);
        }
        private void delete_btn_click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Delete selected item?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
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
            else if (result == MessageBoxResult.No)
            {
                Read();
            }
            
        }
        private void edit_btn_click(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                if (inventory_list.SelectedItems.Count > 0)
                {
                    EditInventory gotopage = new EditInventory();
                    this.NavigationService.Navigate(gotopage);
                }
                else
                    MessageBox.Show("Please select a product to edit!");
            }            
        }
        private void inventory_list_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            delete_btn.IsEnabled = true;
            edit_btn.IsEnabled = true;
        }

        public void Read()
        {
            
            var db = new DataContext();
            inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products").ToList();
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {         
            if (!String.IsNullOrEmpty(SearchField.Text) && Category_Cmbox.SelectedIndex > -1)
            {
                using (DataContext context = new DataContext())
                {
                    MessageBox.Show("Hello 1");
                    var input = SearchField.Text + "%";
                    ComboBoxItem combCategory = (ComboBoxItem)Category_Cmbox.SelectedItem;
                    string category = combCategory.Content.ToString();
                    MessageBox.Show(input + category);
                    inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0} AND Category = {1}", input, category).ToList();                 
                }
            }
            else if(!String.IsNullOrEmpty(SearchField.Text) && Category_Cmbox.SelectedIndex == -1)
            {
                using (DataContext context = new DataContext())
                {
                    MessageBox.Show("Hello 2");

                    var input = SearchField.Text + "%";
                    ComboBoxItem combCategory = (ComboBoxItem)Category_Cmbox.SelectedItem;
                    MessageBox.Show(input);
                    inventory_list.ItemsSource = context.Products.FromSqlRaw("Select * from Products where ProductName like {0}", input).ToList();
                }
            }
        }
        private void Category_Cmbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem category = (ComboBoxItem)Category_Cmbox.SelectedItem;
            string strCategory = category.Content.ToString();
            SearchField.Text = String.Empty;
            var db = new DataContext();           

            inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products where Category = {0}", strCategory).ToList();           
        }               
    }
}
