using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using SHOP.DBModel;

namespace SHOP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Storage.xaml
    /// </summary>
    public partial class Storage : Page
    {
        public Storage()
        {
            InitializeComponent();
            UpdateData();
            if (Manager.User.RoleId != 2)
                DeleteBt.Visibility = Visibility.Collapsed;
        }

        private void UpdateData()
        {
            List<Product> products = DatabaseContext.db.Product.ToList();
            products = Search(products);
            DGridPage.ItemsSource = products;
        }

        private void SearchBox_OnTextChanged(object sender, TextChangedEventArgs e) => UpdateData();

        private List<Product> Search(List<Product> suppliers)
        {
            List<Product> currentSuppliers = suppliers;
            string searchStr = SearchBox.Text;
            currentSuppliers = currentSuppliers.Where(p => p.Title.ToLower().Contains(searchStr.ToLower())).ToList();
            return currentSuppliers;
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.EditStorage((sender as Button).DataContext as Product));
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.EditStorage(null));
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            var productForRemoving = DGridPage.SelectedItems.Cast<Product>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {productForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    DatabaseContext.db.Product.RemoveRange(productForRemoving);
                    DatabaseContext.db.SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                    DGridPage.ItemsSource = DatabaseContext.db.Product.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DatabaseContext.db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridPage.ItemsSource = DatabaseContext.db.Product.ToList();
            }
        }
    }
}
