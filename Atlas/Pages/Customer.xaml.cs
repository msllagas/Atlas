using Atlas.Model_Classes;
using Microsoft.EntityFrameworkCore;
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

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Page
    {
        public Customer()
        {
            InitializeComponent();
            Read();
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Delivery gotopage = new Delivery();
            this.NavigationService.Navigate(gotopage);
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer gotopage = new AddCustomer();
            this.NavigationService.Navigate(gotopage);
        }

        public void Read()
        {
            var db = new DataContext();
            customer_list.ItemsSource = db.Customers.FromSqlRaw("Select * from Customers").ToList();   
        }

        private void customer_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void del_btn_click(object sender, RoutedEventArgs e)
        {
            if (customer_list.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a customer to be deleted!");
            }
            else if (customer_list.SelectedItems.Count > 0)
            {
                var result = MessageBox.Show("Delete selected customer?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    using (DataContext context = new DataContext())
                    {
                        
                            CSCustomer delCustomer = customer_list.SelectedItem as CSCustomer;
                            context.Remove(delCustomer);
                            context.SaveChanges();
                            Read();
                    }
                }
                else if (result == MessageBoxResult.No)
                {
                    Read();
                }
            }
           
        }
    }
}
