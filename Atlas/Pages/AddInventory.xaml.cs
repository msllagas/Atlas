using Atlas.Model_Classes;
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

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for AddInventory.xaml
    /// </summary>
    public partial class AddInventory : Page
    {
        public AddInventory()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Create();
            Inventory gotopage = new Inventory();
            this.NavigationService.Navigate(gotopage);
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Inventory gotopage = new Inventory();
            this.NavigationService.Navigate(gotopage);
        }

        public void Create()
        {
            using (DataContext context = new DataContext())
            {
                var product = product_name.Text;
                var cost = float.Parse(price.Text);
                var measure = measurement.Text;
                var _color = color.Text;
                var _category = category.Text;
                var _status = status.Text;
                var _stocks = stocks.Text;


                if (product != null && cost != null && _color != null && _category != null && _status != null && _stocks != null)
                {
                    context.Products.Add(new CSProduct() { ProductName = product, 
                                                            Price = cost,
                                                            Measurement = measure,
                                                            Color = _color,
                                                            Category = _category,
                                                            Status = _status,
                                                            Stocks = _stocks});
                    context.SaveChanges();
                }

            }
        }
    }
}
