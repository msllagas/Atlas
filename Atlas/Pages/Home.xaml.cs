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
            HighestSale.ItemsSource = Products.GetHighestSales();
            SalesTable.ItemsSource = Products.GetYearlySales();

            SetProductCount();
        }
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
        public class Products : INotifyPropertyChanged
        {           
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

            private int sold;
            public int TotalSold
            {
                get { return sold; }
                set
                {
                    sold = value;
                    RaiseProperChanged();
                }
            }

            private int quantity;
            public int TotalQuantity
            {
                get { return quantity; }
                set
                {
                    quantity = value;
                    RaiseProperChanged();
                }
            }

            public static ObservableCollection<Products> GetHighestSales()
            {
                var item = new ObservableCollection<Products>();
                item.Add(new Products()
                {
                    ProductName = "001",
                    TotalSold = 10,
                    TotalQuantity = 1,
                    
                });
                item.Add(new Products()
                {
                    ProductName = "001",
                    TotalSold = 10,
                    TotalQuantity = 1,

                });
                return item;
            }

            private string month;
            public string Month
            {
                get { return month; }
                set
                {
                    month = value;
                    RaiseProperChanged();
                }
            }

            private int sales;
            public int Sales
            {
                get { return sales; }
                set
                {
                    sales = value;
                    RaiseProperChanged();
                }
            }

            private int dif;
            public int Difference
            {
                get { return dif; }
                set
                {
                    dif = value;
                    RaiseProperChanged();
                }
            }

            public static ObservableCollection<Products> GetYearlySales()
            {
                var item = new ObservableCollection<Products>();
                item.Add(new Products()
                {
                    Month = "January",
                    Sales = 10,
                    Difference = 1,

                });
                item.Add(new Products()
                {
                    Month = "February",
                    Sales = 10,
                    Difference = 1,

                });
                item.Add(new Products()
                {
                    Month = "March",
                    Sales = 10,
                    Difference = 1,

                });
                item.Add(new Products()
                {
                    Month = "April",
                    Sales = 10,
                    Difference = 1,

                });
                item.Add(new Products()
                {
                    Month = "May",
                    Sales = 10,
                    Difference = 1,

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
    }
}
