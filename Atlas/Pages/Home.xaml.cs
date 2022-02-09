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
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        public Home()
        {
            InitializeComponent();
            Read();
            SetProductCount();
            SetCategoryCount();
            SetSalesCount();

        }

        //For counting the Products
        public void  SetProductCount()
        {
            using (DataContext context = new DataContext()) 
            {
                List<CSProduct> products = context.Products.ToList();
                if (products.Count > 0)
                    productCount.Content = products.Count;
                else
                    productCount.Content = "0";
            }
            
        }

        //For counting the Category
        public void SetCategoryCount()
        {
            categoryCount.Content = "4";
        }

        //For counting the Total Sales
        public void SetSalesCount()
        {
            using (DataContext context = new DataContext())
            {
                var totalsales = context.Orderitems.Sum(t => t.TotPrice);
                salesCount.Content = totalsales.ToString();
            }
        }

        //For reading the top 3 Products
        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                var topitems = context.Topchosen.FromSqlRaw("SELECT ProductName, TotalPrice as TotalSold, Quantity as TotalQuantity FROM (SELECT ProductID, SUM(TotPrice) as TotalPrice, SUM(Quantity) as Quantity FROM Orderitems GROUP by ProductID Order By TotPrice DESC) as a Join Products on a.ProductID = Products.ID Order By TotalPrice DESC LIMIT 3 ");
                HighestSale.ItemsSource = topitems.ToList();
            }

        }
       
    }
}
