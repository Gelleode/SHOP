using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static System.Int32;

namespace SHOP.Pages
{
    /// <summary>
    /// Логика взаимодействия для StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        public StatisticsPage()
        {
            InitializeComponent();

            int totalSum = 0;
            int totalSales = 0;
            int maxSale = MinValue;
            int minSale = MaxValue;
            foreach (var order in DatabaseContext.db.Order)
            {
                totalSum += order.Product.Price * order.Quantity;
                totalSales += order.Quantity;
                if (maxSale < order.Product.Price * order.Quantity)
                    maxSale = order.Product.Price * order.Quantity;
                if (minSale > order.Product.Price * order.Quantity)
                    minSale = order.Product.Price * order.Quantity;
            }

            if (maxSale == MinValue)
                maxSale = 0;
            if (minSale == MaxValue)
                minSale = 0;

            AllSumText.Text = Convert.ToString(totalSum);
            AllSaleText.Text = Convert.ToString(totalSales);
            MaxCountText.Text = Convert.ToString(maxSale);
            MinCountText.Text = Convert.ToString(minSale);
        }

        private void MoreInfoBt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.MoreInfoPage());
        }
    }
}
