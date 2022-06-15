using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddNewRecordPage.xaml
    /// </summary>
    public partial class AddNewRecordPage : Page
    {
        private Order _order = new Order();
        private static readonly Regex Regex = new Regex("[^0-9]+");
        public AddNewRecordPage(Order curOrder)
        {
            InitializeComponent();
            StorageBo.ItemsSource = DatabaseContext.db.Product.ToList();
            if (curOrder != null)
            {
                _order = curOrder;
                StorageBo.SelectedItem = curOrder.Product;
            }
            else
                StorageBo.SelectedIndex = 0;
        }
        private static bool IsTextAllowed(string text)
        {
            return !Regex.IsMatch(text);
        }



        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrEmpty(TBoxSurname.Text))
                errors.AppendLine("Поле с фамилией не может быть пустым");
            if (string.IsNullOrEmpty(TBoxName.Text))
                errors.AppendLine("Поле с именем не может быть пустым");
            if (string.IsNullOrEmpty(TBoxPatronymic.Text))
                errors.AppendLine("Поле с отчеством не может быть пустым");
            if (string.IsNullOrEmpty(TBoxAddress.Text))
                errors.AppendLine("Поле с адресом не может быть пустым");
            if (string.IsNullOrEmpty(TBoxPhone.Text))
                errors.AppendLine("Поле с номером не может быть пустым");
            if (string.IsNullOrEmpty(TBoxQuantity.Text))
                errors.AppendLine("Поле с количеством не может быть пустым");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
            {
                if (_order.Id == 0)
                {
                    _order.OrderDate = DateTime.Now;
                    _order.RecieveDate = DateTime.Today.AddDays(7);

                    DatabaseContext.db.Order.Add(_order);
                }
                _order.ProductId = ((Product)StorageBo.SelectedItem).Id;
                _order.Client = new Client()
                {
                    Surname = TBoxSurname.Text.Trim(),
                    Name = TBoxName.Text.Trim(),
                    Patronymic = TBoxPatronymic.Text.Trim(),
                    Address = TBoxAddress.Text.Trim(),
                    Phone = TBoxPhone.Text.Trim(),
                };
                _order.Quantity = Convert.ToInt32(TBoxQuantity.Text);
                
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

        private void TBoxQuantity_OnPreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = Regex.IsMatch(e.Text);
    }
}
