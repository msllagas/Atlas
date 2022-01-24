using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for Delivery.xaml
    /// </summary>
    public partial class Delivery : Page
    {
        private List<Info> items;
        public List<CSDelivery> deliveries { get; private set; }
        public static int TrackingNumber;
        public static int CustomerID;
        public static int ProductID;
        public static int Quantity;
        public static float Total;

        public Delivery()
        {
            InitializeComponent();
            
            
            //CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(delivery_list.ItemsSource);
            //view.Filter = SearchFilter;
            Read();
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
                    ProductID = cSDelivery.ProductID;
                    Quantity = cSDelivery.Quantity;
                    Total = cSDelivery.Amount;
                    Delivery_Item_List gotopage = new Delivery_Item_List();
                    this.NavigationService.Navigate(gotopage);
                }
            }
        }
    }
}
