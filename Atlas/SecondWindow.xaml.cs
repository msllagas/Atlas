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
using System.Windows.Shapes;

namespace Atlas
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            if(toggleButton.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_delivery.Visibility = Visibility.Collapsed;
                tt_inventory.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_delivery.Visibility = Visibility.Visible;
                tt_inventory.Visibility = Visibility.Visible;
            }
        }

        private void toggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void toggleButton_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }
    }
}
