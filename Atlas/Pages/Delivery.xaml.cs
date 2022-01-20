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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Atlas.Model_Classes;
using System.Windows.Controls.Primitives;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for Delivery.xaml
    /// </summary>
    public partial class Delivery : Page
    {
        private List<Info> items;
        public Delivery()
        {
            InitializeComponent();
            
            delivery_list.ItemsSource = GetInfo();
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(delivery_list.ItemsSource);
            view.Filter = SearchFilter;
            // Read();
        }

        private bool SearchFilter(object item)
        {
            
            if (String.IsNullOrEmpty(SearchBar.Text))
                return true;
            else               
                return ((item as Info).Recipient.IndexOf(SearchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    || ((item as Info).Address.IndexOf(SearchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    || ((item as Info).TrackingNumber.IndexOf(SearchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    || ((item as Info).TotalItems.ToString().IndexOf(SearchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    || ((item as Info).TotalAmount.ToString().IndexOf(SearchBar.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void SearchBar_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(delivery_list.ItemsSource).Refresh();
        }
        public List<Info> GetInfo()
        {
            items = new List<Info>();
            items.Add(new Info()
            {
                TrackingNumber = "827365JDH83H7",
                Recipient = "john doe",
                Address = "Manila City",
                TotalItems = 30,
                TotalAmount = 100
            });
            items.Add(new Info()
            {
                TrackingNumber = "8372094NDDH37",
                Recipient = "sammy doe",
                Address = "Calamba City",
                TotalItems = 20,
                TotalAmount = 90.54
            });
            items.Add(new Info()
            {
                TrackingNumber = "92863829",
                Recipient = "Juan Dela Cruz",
                Address = "Manila City",
                TotalItems = 30,
                TotalAmount = 90.54
            });
            return items;
        }
        public class Info
        {            
            public string TrackingNumber { get; set; }
            public string Recipient { get; set; }
            public string Address { get; set; }
            public int TotalItems { get; set; }            
            public double TotalAmount { get; set; }
            public override string ToString()
            {
                return "Tracking No. "+this.TrackingNumber+"\n"+this.Recipient+"\n"+this.Address
                    +"\nItems: "+this.TotalItems+"\tAmount: "+this.TotalAmount;
            }
        }
        private void delivery_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }     

        public void Read()
        {
            
        }

        private void add_btn_click(object sender, RoutedEventArgs e)
        {
            AddDelivery gotopage = new AddDelivery();
            this.NavigationService.Navigate(gotopage);
        }

        private void item_dbl_click(object sender, MouseButtonEventArgs e)
        {
            var item = delivery_list.SelectedItem;
            if (item != null)
            {
                Delivery_Item_List gotopage = new Delivery_Item_List();
                this.NavigationService.Navigate(gotopage);
                //MessageBox.Show(item + " Double Click handled!");
            }     
        }
    }
}
