using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using SHOP.DBModel;

namespace SHOP.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditStorage.xaml
    /// </summary>
    public partial class EditStorage : Page
    {
        private Product _currentProduct = new Product();
        public EditStorage(Product selectedProduct)
        {
            if (selectedProduct != null)
            {
                _currentProduct = selectedProduct;
            }
            InitializeComponent();
            DataContext = _currentProduct;
            ProviderComboBox.ItemsSource = DatabaseContext.db.Supplier.ToList();
        }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentProduct.Title))
                errors.AppendLine("Поле с названием не может быть пустым");
            if (_currentProduct.Price < 0)
                errors.AppendLine("Цена не может быть отрицательной");
            if (_currentProduct.CountInStock < 0)
                errors.AppendLine("Количество не может быть отрицательным");
            if (_currentProduct.Supplier == null)
                errors.AppendLine("Выберите поставщика");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (_currentProduct.Id == 0)
                {
                    DatabaseContext.db.Product.Add(_currentProduct);
                }
                DatabaseContext.db.SaveChanges();
                MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\nПроверьте правильность заполнения полей", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        private void CancelBt_Click(object sender, RoutedEventArgs e)
        {
            TitleText.Clear();
            PriceText.Clear();
            AllCountText.Clear();
            Manager.MainFrame.GoBack();
        }
    }
}
