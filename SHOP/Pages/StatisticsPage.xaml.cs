using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            var payment = DatabaseContext.db.ProductOrder;

            int totalSum = 0;
            foreach (var po in payment) 
                totalSum += po.Product.Price * po.Quantity;
            
            AllSumText.Text = Convert.ToString(totalSum);
            AllSaleText.Text = Convert.ToString(payment.Sum(p=>p.Quantity));
            MaxCountText.Text = Convert.ToString(payment.Max(p=>p.Quantity));
            MinCountText.Text = Convert.ToString(payment.Min(p =>p.Quantity));
        }

        private void MoreInfoBt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.MoreInfoPage());
        }
    }
}
