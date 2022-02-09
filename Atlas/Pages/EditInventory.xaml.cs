using System.Windows;
using System.Windows.Controls;
using Atlas.Model_Classes;

namespace Atlas.Pages
{
    /// <summary>
    /// Interaction logic for EditInventory.xaml
    /// </summary>
    public partial class EditInventory : Page
    {
        
        public EditInventory()
        {
            InitializeComponent();
            Read();
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Inventory gotopage = new Inventory();
            this.NavigationService.Navigate(gotopage);
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                var _productName = productName.Text;
                var _measurement = measurement.Text;
                var _color = color.Text;
                var _price = price.Text;
                var _category = category.Text;
                var _stocks = stocks.Text;
                var _brand = brand.Text;
                if (productName.Text != null && measurement.Text != null && color.Text != null && 
                    price.Text != null && category.Text != null && stocks.Text != null && brand.Text != null)
                {

                    CSProduct product = context.Products.Find(Inventory.ID);
                    product.ProductName = _productName;
                    product.Brand = _brand;
                    product.Measurement = _measurement;
                    product.Color = _color;
                    product.Price =  float.Parse( _price);
                    product.Category = _category;
                    product.Stocks = int.Parse( _stocks);
                    context.SaveChanges();
                }

                MessageBox.Show("Changes Saved!");
            }

        }
        private void Read()
        {
            using (DataContext context = new DataContext())
            {
                CSProduct product = context.Products.Find(Inventory.ID);
                productID.Text = Inventory.ID.ToString();
                productName.Text = product.ProductName;
                brand.Text = product.Brand;
                measurement.Text = product.Measurement;
                color.Text = product.Color;
                price.Text = product.Price.ToString();
                category.Text = product.Category;
                stocks.Text = product.Stocks.ToString();

            }

        }
    }
}
