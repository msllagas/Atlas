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
using Microsoft.EntityFrameworkCore;

namespace Atlas.Pages
{
    
    /// <summary>
    /// Interaction logic for AddDelivery.xaml
    /// </summary>
    public partial class AddDelivery : Page
    {
        public static CSCustomer selectedCus;

        public AddDelivery()
        {

            InitializeComponent();
            Read();
            //var db = new DataContext();

            //addItemList.ItemsSource = db.getProductName.FromSqlRaw("Select ProductName From Products").ToList();
        }       

        //public void Create()
        //{
        //    using (DataContext context = new DataContext())
        //    {
        //        var _name = receipient.Text;
        //        var _address = address.Text;
        //        //var _amount = float.Parse(amount.Text);
        //        //var _quantity = int.Parse(quantity.Text);
        //        //var _product = int.Parse(product.Text);

        //        CSCustomer cSCustomer = new CSCustomer { CustomerName = _name, Address = _address };
        //        //if (_name != null && _address != null && _amount != 0 && _quantity != 0 && _product != 0)
        //        //{
        //        //    context.Customers.Add(cSCustomer);
        //        //    context.SaveChanges();

        //        //    int id = cSCustomer.ID;

        //        //    context.Deliveries.Add(new CSDelivery() { CustomerID = id, ProductID = _product, Quantity = _quantity, Amount = _amount });
        //        //    context.SaveChanges();
        //        //}

                
        //    }
        //}

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            //Create();            
            Delivery gotopage = new Delivery();
            this.NavigationService.Navigate(gotopage);
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Delivery gotopage = new Delivery();
            this.NavigationService.Navigate(gotopage);
        }

        private void inventory_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btn_Order_Click(sender, e);
        }
        public void Read()
        {

            var db = new DataContext();

            //inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products").ToList();
            customer_list.ItemsSource = db.Customers.FromSqlRaw("Select * from Customers").ToList();

            //using (DataContext context = new DataContext())
            //{
            //    products = context.Products.ToList();

            //    if (products.Count > 0)
            //        inventory_list.ItemsSource = products;
            //}
        }

       

        //private void Category_Cmbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ComboBoxItem category = (ComboBoxItem)Category_Cmbox.SelectedItem;

        //    string strCategory = category.Content.ToString();
        //    var db = new DataContext();

        //    inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products where Category = {0}", strCategory).ToList();
        //    //MessageBox.Show(category.Content.ToString());
        //}

        private void customer_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //inventory_list_SelectionChanged(sender, e);
            
        }

        private void proceed_btn_Click(object sender, RoutedEventArgs e)
        {
            selectedCus = (CSCustomer)customer_list.SelectedItems[0];
            _2ndPageAddDel gotopage = new _2ndPageAddDel();

            this.NavigationService.Navigate(gotopage);
        }

        //private void btn_Order_Click(object sender, RoutedEventArgs e)
        //{
        //    orderBtn(sender);
        //}


        //private void orderBtn(object sender)
        //{
        //    Button targetbutton = (sender as Button);

        //    if(targetbutton != null && targetbutton.Name == "btn_Order")
        //    {


        //        using (DataContext context = new DataContext())
        //        {

        //            CSCustomer selCustomer = (CSCustomer)customer_list.SelectedItems[0];
        //            CSProduct selProduct = (CSProduct)inventory_list.SelectedItems[0];

        //            var quantityval = int.Parse(quantityValue.Text);
        //            var uprice = float.Parse(selProduct.Price.ToString());
        //            var customerid = selCustomer.ID.ToString();
        //            var productnameval = selProduct.ProductName.ToString();

        //            var iniTotal = quantityval * uprice;


        //            if (productnameval != null)
        //            {
        //                context.Orders.Add(new Orderlist()
        //                {
        //                    ProductName = productnameval,
        //                    Quantity = quantityval,
        //                    Price = uprice,
        //                    Total = iniTotal
        //                });

        //                //int curStocks = int.Parse(selProduct.Stocks);
        //                //string upStocks = (curStocks - quantityval).ToString();

        //                selProduct.Stocks = selProduct.Stocks - quantityval;
        //                //selProduct.Stocks = (curStocks - quantityval).ToString();
        //                context.Products.Update(selProduct);
        //                context.SaveChanges();


        //                var db = new DataContext();
        //                initial_Order.ItemsSource = db.Orders.FromSqlRaw("Select * from Orders").ToList();

        //                Read();
        //            }

        //        }
        //        //Orderlist order = new Orderlist
        //        //{
        //        //    ProductName = productname,
        //        //    Quantity = quantity,
        //        //    Price = uprice,
        //        //    Total = iniTotal
        //        //};




        //        //MessageBox.Show(selCustomer.Address.ToString());
        //    }
        //}

        //private void initial_Order_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}
    }
}
