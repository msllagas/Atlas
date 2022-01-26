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
        public List<CSDelivery> deliveries { get; private set; }
        public static int TrackingNumber;
        public static int CustomerID;
        public static int ProductID;
        public static int Quantity;
        public static float Total;

        public Delivery()
        {
            InitializeComponent();
            Read();
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(delivery_list.DataContext);
          //  view.Filter = SearchFilter;
        }
        private bool SearchFilter(object item)
        {

            if (String.IsNullOrEmpty(SearchBar.Text))
                return true;
            else
                return ((item as CSDelivery).CustomerID.ToString().IndexOf(SearchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    //|| ((item as CSDelivery).Address.IndexOf(SearchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    || ((item as CSDelivery).TrackingNumber.ToString().IndexOf(SearchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    || ((item as CSDelivery).Quantity.ToString().IndexOf(SearchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    || ((item as CSDelivery).Amount.ToString().IndexOf(SearchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0);
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
                deliveries = context.Deliveries.ToList();

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
                    ProductID = cSDelivery.ProductID; //change product ID to address...
                    Quantity = cSDelivery.Quantity; //display total quantity of items ordered
                    Total = cSDelivery.Amount;      //display total amount of orders                    
                    
                    Delivery_Item_List gotopage = new Delivery_Item_List();
                    this.NavigationService.Navigate(gotopage);
                }
            }
        }
    }
}
