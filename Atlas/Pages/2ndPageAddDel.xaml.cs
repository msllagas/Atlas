﻿using Atlas.Model_Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for _2ndPageAddDel.xaml
    /// </summary>
    public partial class _2ndPageAddDel : Page
    {
        private static float Price;

        ObservableCollection<iniOrder> iniitem = new ObservableCollection<iniOrder>();

        public _2ndPageAddDel()
        {
            InitializeComponent();
            Read();
            SelCustomer();
        }
        private void inventory_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btn_Order_Click(sender, e);
        }
        private void initial_Order_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        //Category filter
        private void Category_Cmbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem category = (ComboBoxItem)Category_Cmbox.SelectedItem;

            string strCategory = category.Content.ToString();
            var db = new DataContext();

            inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products where Category = {0}", strCategory).ToList();
            //MessageBox.Show(category.Content.ToString());
        }
        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Cancel_Orders();
        }

        //Parcel is added to delivery
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            //Create();
            Random rnd = new Random();
            int TrackingNum = rnd.Next(100000, 199999);

            using (DataContext context = new DataContext())
            {
                if (initial_Order.HasItems)
                {
                    var finOrder = iniitem.ToList();

                    int custQuantity = 0;
                    float custTotal = 0;

                    foreach (var eachorder in finOrder)
                    {
                        var finalID = int.Parse(eachorder.ProductID.ToString());
                        var finalQuan = int.Parse(eachorder.Quantity.ToString());
                        var finalpri = float.Parse(eachorder.Price.ToString());
                        var finaltot = float.Parse(eachorder.Total.ToString());

                        context.Orderitems.Add(new CSOrderitems()
                        {
                            TrackingNumber = TrackingNum,
                            ProductID = finalID,
                            Quantity = finalQuan,
                            UnitPrice = finalpri,
                            TotPrice = finaltot
                        });

                        custQuantity += finalQuan;
                        custTotal += finaltot;


                    }
                    foreach (var item in finOrder)
                    {
                        iniitem.Remove(item);
                    }
                    DateTime date = DateTime.Now;
                    CultureInfo ci = CultureInfo.InvariantCulture;

                    var orderdate = date.ToString("yyyy-MM-dd HH:mm:ss", ci);
                    var customerid = AddDelivery.selectedCus.ID;
                    var custaddress = AddDelivery.selectedCus.Address;


                    context.Deliveries.Add(new CSDelivery()
                    {
                        TrackingNumber = TrackingNum,
                        CustomerID = customerid,
                        Address = custaddress,
                        Amount = custTotal,
                        Quantity = custQuantity,
                        OrderDate = orderdate

                    });

                    context.SaveChanges();
                    MessageBox.Show("Done!");
                    Read();
                }
                else
                    MessageBox.Show("No products to add!");
            }


        }


        private void btn_Order_Click(object sender, RoutedEventArgs e)
        {
            orderBtn(sender);
            try
            {
                totalamount.Text = Convert.ToString(Price * float.Parse(quantityValue.Text));
            }
            catch (Exception)
            {
            }

        }


        //For initial orders
        private void orderBtn(object sender)
        {

            try
            {
                CSProduct selProduct = (CSProduct)inventory_list.SelectedItems[0];
                Button targetbutton = (sender as Button);



                if (targetbutton != null && targetbutton.Name == "btn_Order")
                {
                    if (inventory_list.SelectedItems.Count > 0)
                    {
                        using (DataContext context = new DataContext())
                        {


                            var db = new DataContext();


                            var quantityval = int.Parse(quantityValue.Text);
                            var uprice = float.Parse(selProduct.Price.ToString());
                            var productnameval = selProduct.ProductName.ToString();
                            var prodid = int.Parse(selProduct.ID.ToString());

                            var iniTotal = quantityval * uprice;
                            Price = selProduct.Price;


                            var id = selProduct.ID;

                            if (selProduct.Stocks >= int.Parse(quantityValue.Text) && selProduct.Stocks != 0)
                            {

                                if (iniitem.Any(p => p.ProductID == id))
                                {
                                    MessageBox.Show("Already exists");
                                    iniOrder duplicateOrd = iniitem.Where(x => x.ProductID == id).FirstOrDefault();
                                    var requantityval = duplicateOrd.Quantity + quantityval;
                                    duplicateOrd.Quantity = requantityval;
                                    duplicateOrd.Total = requantityval * duplicateOrd.Price;
                                    selProduct.Stocks = selProduct.Stocks - quantityval;
                                    context.Products.Update(selProduct);
                                    context.SaveChanges();
                                }
                                else if (!iniitem.Any(p => p.ProductID == id))
                                {
                                    MessageBox.Show("Added! Second");
                                    iniitem.Add(new iniOrder()
                                    {
                                        ProductID = prodid,
                                        ProductName = productnameval,
                                        Quantity = quantityval,
                                        Price = uprice,
                                        Total = iniTotal
                                    });
                                    selProduct.Stocks = selProduct.Stocks - quantityval;
                                    context.Products.Update(selProduct);
                                    context.SaveChanges();
                                }
                                Read();


                            }
                            else if (selProduct.Stocks == 0)
                            {
                                MessageBox.Show("Selected Product is out of stocks!");
                            }
                            else
                                MessageBox.Show("Stocks is lower than the quantity required");

                        }
                    }

                    else
                        MessageBox.Show("Please select a Product!");

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Select Product First!");
            }


        }

        //Reads from local database
        public void Read()
        {

            var db = new DataContext();

            inventory_list.ItemsSource = db.Products.FromSqlRaw("Select * from Products").ToList();
            //initial_Order.ItemsSource = db.Orders.FromSqlRaw("Select * from Orders").ToList();
            initial_Order.ItemsSource = iniitem;
        }

        //Goes back
        private void go_back_btn_click(object sender, RoutedEventArgs e)
        {
            Cancel_Orders();
            AddDelivery gotopage = new AddDelivery();
            this.NavigationService.Navigate(gotopage);
        }

        //Selects customer
        public void SelCustomer()
        {
            sel_Customerlbl.Content = AddDelivery.selectedCus.CustomerName.ToString();
        }

        //Deletes initial orders
        public void Cancel_Orders()
        {
            using (DataContext context = new DataContext())
            {
                //var cancelOrder = context.Orders.FromSqlRaw("Select * From Orders").ToList();

                //foreach (var item in cancelOrder)
                //{
                //    var cancelOrderQuantity = item.Quantity;
                //    var productUpdate = context.Products.Single(b => b.ID == item.ProductID);
                //    productUpdate.Stocks += cancelOrderQuantity;
                //    context.Products.Update(productUpdate);
                //}

                var cancelOrder = iniitem.ToList();

                foreach (var item in cancelOrder)
                {
                    var cancelOrderQuantity = item.Quantity;
                    var productUpdate = context.Products.Single(b => b.ID == item.ProductID);
                    productUpdate.Stocks += cancelOrderQuantity;
                    context.Products.Update(productUpdate);
                    iniitem.Remove(item);
                }
                context.SaveChanges();

                //foreach (var item in cancelOrder)
                //{

                //}

                MessageBox.Show("Done!");

                Read();
            }
        }


        public class iniOrder : INotifyPropertyChanged
        {
            private int idvalue;
            public int ID { get { return idvalue; } set { idvalue = value; RaiseProperChanged(); } }

            private int prodidvalue;
            public int ProductID { get { return prodidvalue; } set { prodidvalue = value; RaiseProperChanged(); } }

            private string prodnamevalue;
            public string ProductName { get { return prodnamevalue; } set { prodnamevalue = value; RaiseProperChanged(); } }

            private int quantityvalue;
            public int Quantity { get { return quantityvalue; } set { quantityvalue = value; RaiseProperChanged(); } }

            private float pricevalue;
            public float Price { get { return pricevalue; } set { pricevalue = value; RaiseProperChanged(); } }

            private float totalvalue;
            public float Total { get { return totalvalue; } set { totalvalue = value; RaiseProperChanged(); } }

            public event PropertyChangedEventHandler PropertyChanged;
            private void RaiseProperChanged([CallerMemberName] string caller = "")
            {

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(caller));
                }
            }

        }










    }

}