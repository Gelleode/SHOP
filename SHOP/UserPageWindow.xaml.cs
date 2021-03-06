using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SHOP.Pages;

namespace SHOP
{
    /// <summary>
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        public UserPageWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.Storage());
            LabelUser.Content = Manager.User.Login;
            Manager.MainFrame = MainFrame;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            var Content = MainFrame.Content;
            if (Content.GetType() == typeof(Storage) ||
                Content.GetType() == typeof(Provider) ||
                Content.GetType() == typeof(NotePage) ||
                Content.GetType() == typeof(StatisticsPage))
            {
                BtnBack.Visibility = Visibility.Hidden;
                return;
            }
            if (MainFrame.CanGoBack)
            {
                BtnBack.Visibility = Visibility.Visible;
            }
            else
            {
                BtnBack.Visibility = Visibility.Hidden;
            }
        }

        private void Storage_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Storage());
        }

        private void Provider_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Provider());
        }

        private void Stat_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new StatisticsPage());
        }

        private void Note_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new NotePage());
        }
    }
}
