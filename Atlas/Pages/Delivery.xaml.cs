using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for Delivery.xaml
    /// </summary>
    public partial class Delivery : Page
    {

        public List<CSDelivery> deliveries { get; private set; }

        public Delivery()
        {
            InitializeComponent();
            Read();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void delivery_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public void Read()
        {
            using (DataContext context = new DataContext())
            {
                deliveries = context.Deliveries.ToList();


                if (deliveries.Count > 0)
                    delivery_list.ItemsSource = deliveries;
            }
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            Read();
        }

        private void add_btn_click(object sender, RoutedEventArgs e)
        {
            AddDelivery gotopage = new AddDelivery();
            this.NavigationService.Navigate(gotopage);
        }
    }
}
