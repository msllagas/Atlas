using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for Delivery.xaml
    /// </summary>
    public partial class Delivery : Page
    {
        public static CSDelivery selectedDel;

        public List<CSDelivery> deliveries { get; private set; }
        public static int TrackingNumber;
        public static int CustomerID;
        public static string Address;
        public static int Quantity;
        public static float Total;
        public static string OrderDate;

        public Delivery()
        {
            InitializeComponent();
            Read();       
        }
       
        private void SearchBar_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(delivery_list.ItemsSource).Refresh();
        }
       
        private void delivery_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }     

        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                //deliveries = context.Deliveries.ToList();
                deliveries = context.Deliveries.OrderByDescending(d => d.OrderDate).ToList();

                if (deliveries.Count > 0)
                    delivery_list.ItemsSource = deliveries;
            }
        }

        private void add_btn_click(object sender, RoutedEventArgs e)
        {
            AddDelivery gotopage = new AddDelivery();
            this.NavigationService.Navigate(gotopage);
        }

        private void item_dbl_click(object sender, MouseButtonEventArgs e)
        {   
            using (DataContext context = new DataContext())
            {
                var item = delivery_list.SelectedItem as CSDelivery;
                
                if(item != null)
                {
                    CSDelivery cSDelivery = context.Deliveries.Find(item.TrackingNumber);
                    TrackingNumber = cSDelivery.TrackingNumber;
                    CustomerID = cSDelivery.CustomerID;
                    Address = cSDelivery.Address; //change product ID to address...
                    Quantity = cSDelivery.Quantity; //display total quantity of items ordered
                    Total = cSDelivery.Amount;      //display total amount of orders
                    OrderDate = cSDelivery.OrderDate;                         
                    selectedDel = (CSDelivery)delivery_list.SelectedItems[0];

                    Delivery_Item_List gotopage = new Delivery_Item_List();
                    this.NavigationService.Navigate(gotopage);
                }
            }
        }

        private void btnCustomer(object sender, RoutedEventArgs e)
        {
            Customer gotopage = new Customer();
            this.NavigationService.Navigate(gotopage);
        }
        private void edit_btn_click(object sender, RoutedEventArgs e)
        {

        }

        private void delivery_list_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            delete_btn.IsEnabled = true;
        }

        private void delete_order(object sender, RoutedEventArgs e)
        {

            var result = MessageBox.Show("Delete selected item?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            if (result == MessageBoxResult.Yes)
            {
                using (DataContext context = new DataContext())
                {
                    if(delivery_list.SelectedItems.Count > 0)
                    {

                        CSDelivery delOrder = delivery_list.SelectedItem as CSDelivery;

                        context.Remove(delOrder);
                        context.SaveChanges();
                        Read();
                    }
                     else
                        MessageBox.Show("Please select an order to be deleted!");
                    }
            }
            else if (result == MessageBoxResult.No)
            {
                Read();
            }


            //using (DataContext context = new DataContext())
            //{
            //    if (delivery_list.SelectedItems.Count > 0)
            //    {

            //        CSDelivery delOrder = delivery_list.SelectedItem as CSDelivery;

            //        context.Remove(delOrder);
            //        context.SaveChanges();
            //        Read();
            //    }
            //    else
            //        MessageBox.Show("Please select an order to be deleted!");
            //}
        }        
    }
}
