using SHOP.DBModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SHOP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Provider.xaml
    /// </summary>
    public partial class Provider : Page
    {
        public Provider()
        {
            InitializeComponent();
            if (Manager.User.RoleId != 2)
                DeleteBt.Visibility = Visibility.Collapsed;
            UpdateList();
        }

        private void UpdateList()
        {
            List<Supplier> currentSuppliers = DatabaseContext.db.Supplier.ToList();
            currentSuppliers = Search(currentSuppliers);
            LViewProviders.ItemsSource = currentSuppliers;
        }

        private List<Supplier> Search(List<Supplier> suppliers)
        {
            List<Supplier> currentSuppliers = suppliers;
            string searchStr = SearchBox.Text;
            currentSuppliers = currentSuppliers.Where(p => p.Name.ToLower().Contains(searchStr.ToLower())).ToList();
            return currentSuppliers;
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.EditProviders((sender as Button).DataContext as Supplier));
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Pages.EditProviders(null));
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            var providersForRemoving = LViewProviders.SelectedItems.Cast<Supplier>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {providersForRemoving.Count()} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    DatabaseContext.db.Supplier.RemoveRange(providersForRemoving);
                    DatabaseContext.db.SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                    LViewProviders.ItemsSource = DatabaseContext.db.Supplier.ToList();
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
                LViewProviders.ItemsSource = DatabaseContext.db.Supplier.ToList();
            }
        }

        private void SearchBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }
    }
}
