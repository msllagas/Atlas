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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Atlas.Model_Classes;
using Atlas.Pages;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for Delivery_Item_List.xaml
    /// </summary>
    public partial class Delivery_Item_List : Page
    {
        public Delivery_Item_List()
        {
            InitializeComponent();
            itemsTable.ItemsSource = Products.GetProducts();
            DataContext = Products.GetInfo();
        }

        public class Products : INotifyPropertyChanged
        {
            private string prodID;
            public string ProductID
            {
                get { return prodID; }
                set
                {
                    prodID = value;
                    RaiseProperChanged();
                }
            }
            private string name;
            public string ProductName
            {
                get { return name; }
                set
                {
                    name = value;
                    RaiseProperChanged();
                }
            }
            private int quantity;
            public int Quantity
            {
                get { return quantity; }
                set
                {
                    quantity = value;
                    RaiseProperChanged();
                }
            }
            private string unit;
            public string UnitCost
            {
                get { return unit; }
                set
                {
                    unit = value;
                    RaiseProperChanged();
                }
            }
            private string total;
            public string TotalCost
            {
                get { return total; }
                set
                {
                    total = value;
                    RaiseProperChanged();
                }
            }
            public string _TrackingNumber;
            public string TrackingNumber { get { return _TrackingNumber; } set { _TrackingNumber = value; } }
            public string _Recipient;
            public string Recipient { get; set; }
            public string _Address;
            public string Address { get; set; }
            public int _TotalItems;
            public int TotalItems { get; set; }
            public double _TotalAmount;
            public double TotalAmount { get; set; }

            public static ObservableCollection<Products> GetInfo()
            {
                var order = new ObservableCollection<Products>();
                order.Add(new Products()
                {
                    TrackingNumber = "001",
                    Recipient = "Juan",
                    Address = "Laguna",
                    TotalItems = 5,
                    TotalAmount = 167.96
                });                
                return order;
            }
            public static ObservableCollection<Products> GetProducts()
            {
                var item = new ObservableCollection<Products>();
                item.Add(new Products()
                {
                    ProductID = "001",
                    ProductName = "Gtech Sign Pen C-3",
                    Quantity = 1,
                    UnitCost = "P70.00",
                    TotalCost = "P70.00"
                });
                item.Add(new Products()
                {
                    ProductID = "002",
                    ProductName = "Mongol 08",
                    Quantity = 11,
                    UnitCost = "P70.00",
                    TotalCost = "P70.00"
                });
                return item;
            }

            public event PropertyChangedEventHandler PropertyChanged;
            private void RaiseProperChanged([CallerMemberName] string caller = "")
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(caller));
                }
            }
        }
        private void close_btn_click(object sender, RoutedEventArgs e)
        {
            Delivery gotopage = new Delivery();
            this.NavigationService.Navigate(gotopage);
        }
    }
}
