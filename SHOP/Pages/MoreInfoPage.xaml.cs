using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using SHOP.DBModel;

namespace SHOP.Pages
{
    /// <summary>
    /// Логика взаимодействия для MoreInfoPage.xaml
    /// </summary>
    public partial class MoreInfoPage : Page
    {
        public MoreInfoPage()
        {
            InitializeComponent();
            DGridPage.ItemsSource = DatabaseContext.db.Order.ToList();
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddNewRecordPage(null));
        }
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DatabaseContext.db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridPage.ItemsSource = DatabaseContext.db.Order.ToList();
            }
        }

        private void BtnToExcel_OnClick(object sender, RoutedEventArgs e)
        {
            var order = (sender as Button).DataContext as Order;
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files(*.csv)|*.csv|All files(*.*)|*.*",
                FileName = "unknown",
                DefaultExt = ".csv",
                OverwritePrompt = true
            };
            if (saveFileDialog.ShowDialog() == false) return;
            try
            {
                using (StreamWriter writer =
                       new StreamWriter(
                           new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write),
                           Encoding.UTF8))
                {
                    writer.WriteLine("ID;");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
