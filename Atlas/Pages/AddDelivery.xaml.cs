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
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Atlas.Model_Classes;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for AddDelivery.xaml
    /// </summary>
    public partial class AddDelivery : Page
    {
        public AddDelivery()
        {
            InitializeComponent();
            addTable.ItemsSource = Products.GetProducts();
        }

        public class Products :INotifyPropertyChanged
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

            public static ObservableCollection<Products> GetProducts()
            {
                var item = new ObservableCollection<Products>();
                item.Add(new Products()
                {
                    ProductID = "001",
                    ProductName = "Gtech",
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
        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Delivery gotopage = new Delivery();
            this.NavigationService.Navigate(gotopage);
        }

        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                var _name = receipient.Text;
                var _address = address.Text;
                var _amount = float.Parse(amount.Text);
                var _quantity = int.Parse(quantity.Text);
                var _product = int.Parse(product.Text);

                CSCustomer cSCustomer
                if (_name != null && _address != null && _amount != 0 && _quantity != 0 && _product != 0)
                {
                    context.Customers.Add(new CSCustomer() { CustomerName = _name, Address = _address});
                    context.SaveChanges();
                    
                }
                if (_name != null && _address != null && _amount != 0 && _quantity != 0 && _product != 0)
                {

                    CSCustomer customer = context.Customers.Find(_name);
                   context.Deliveries.Add(new CSDelivery() { CustomerID = customer.ID, ProductID = _product, Quantity = _quantity, Amount = _amount});
                    context.SaveChanges();

                }

            }
        }
        public void Create2()
        {
            Create();
            using (DataContext context = new DataContext())
            {
                var _name = receipient.Text;
                var _address = address.Text;
                var _amount = float.Parse(amount.Text);
                var _quantity = int.Parse(quantity.Text);
                var _product = int.Parse(product.Text);

                if (_name != null && _address != null && _amount != 0 && _quantity != 0 && _product != 0)
                {

                    CSCustomer customer = context.Customers.Find(_name);
                    context.Deliveries.Add(new CSDelivery() { CustomerID = customer.ID, ProductID = _product, Quantity = _quantity, Amount = _amount });
                    context.SaveChanges();

                }
            }
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            Create2();
            Delivery gotopage = new Delivery();
            this.NavigationService.Navigate(gotopage);
        }
    }
}
