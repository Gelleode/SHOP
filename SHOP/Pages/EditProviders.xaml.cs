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
using SHOP.DBModel;

namespace SHOP.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditProviders.xaml
    /// </summary>
    public partial class EditProviders : Page
    {
        private Supplier _currentProviders = new Supplier();
        public EditProviders(Supplier selectedProviders)
        {
            if (selectedProviders != null)
            {
                _currentProviders = selectedProviders;
            }
            InitializeComponent();
            DataContext = _currentProviders;
        }

        private void SaveBt_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(_currentProviders.Id.ToString())||_currentProviders.Id<0)
                errors.AppendLine("Код поставщика не может быть пустым или отрицательным");
            if (string.IsNullOrEmpty(_currentProviders.Name))
                errors.AppendLine("Наименование не может быть пустым");
            if (string.IsNullOrEmpty(_currentProviders.INN.ToString()))
                errors.AppendLine("ИНН не может быть отрицательным");
            if (string.IsNullOrEmpty(_currentProviders.Address))
                errors.AppendLine("Поле с адресом не может быть пустым");
            if (string.IsNullOrEmpty(_currentProviders.Phone))
                errors.AppendLine("Укажите телефон");
            if (string.IsNullOrEmpty(_currentProviders.DirectorName))
                errors.AppendLine("Поле с руководителем не может быть пустым");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (_currentProviders.Id == 0)
                {
                    DatabaseContext.db.Supplier.Add(_currentProviders);
                }
                ShopEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно изменены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + "\nПроверьте правильность заполнения полей", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelBt_Click(object sender, RoutedEventArgs e)
        {
            TitleText.Clear();
            InnText.Clear();
            AdresText.Clear();
            PhoneText.Clear();
            BossText.Clear();
            Manager.MainFrame.GoBack();
        }
    }
}
