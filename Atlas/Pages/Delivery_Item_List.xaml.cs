﻿using System.Windows;
using System.Windows.Controls;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Atlas.Model_Classes;
using System.Collections.Generic;
using System;

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
            Information();
            
        }
        public void Information()
        {           
            using (DataContext context = new DataContext())
            {
                CSCustomer cSCustomer = context.Customers.Find(Delivery.CustomerID);
                customerName.Content = cSCustomer.CustomerName;
                customerAddress.Content = cSCustomer.Address;
                quantity.Content = Delivery.Quantity;
                total.Content = Delivery.Total;
                trackingNumber.Content = Delivery.TrackingNumber;

                var DeliObject = from p in context.Products
                                 from d in context.Deliveries
                                 where d.CustomerID == 5
                                 select new
                                 {
                                     id = p.ID,
                                     productName = p.ProductName,
                                     price = p.Price,
                                     quantity = d.Quantity,
                                     amount = d.Amount
                                 };
                //foreach (var item in DeliObject)
                //{
                //    MessageBox.Show($"{item.productName} + {item.quantity}");
                //    itemsTable.ItemsSource = item;
                //    //Console.WriteLine();
                //}

                itemsTable.ItemsSource = DeliObject.ToList();

                //itemsTable.ItemsSource = context.DeliInfos.FromSqlRaw("SELECT Products.ID, ProductName, Price, Quantity, Amount " +
                //                                                      "FROM Products " +
                //                                                      "Inner JOIN Deliveries ON Deliveries.ProductID = Products.ID " +
                //                                                      "INNER JOIN Customers ON Customers.ID = Deliveries.CustomerID " +
                //                                                      "WHERE CustomerID = {0}", Delivery.CustomerID).ToList();

            }
        }

       
        private void close_btn_click(object sender, RoutedEventArgs e)
        {
            Delivery gotopage = new Delivery();
            this.NavigationService.Navigate(gotopage);
        }

        private void itemsTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
