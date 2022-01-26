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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Atlas.Model_Classes;
using Atlas.Pages;

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

                CSCustomer cSCustomer = new CSCustomer { CustomerName = _name, Address = _address };
                if (_name != null && _address != null && _amount != 0 && _quantity != 0 && _product != 0)
                {
                    context.Customers.Add(cSCustomer);
                    context.SaveChanges();

                    int id = cSCustomer.ID;

                    context.Deliveries.Add(new CSDelivery() { CustomerID = id, ProductID = _product, Quantity = _quantity, Amount = _amount });
                    context.SaveChanges();
                }
            }
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            Create();            
            Delivery gotopage = new Delivery();
            this.NavigationService.Navigate(gotopage);
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Delivery gotopage = new Delivery();
            this.NavigationService.Navigate(gotopage);
        }
    }
}
