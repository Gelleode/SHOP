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
            ClientBox.ItemsSource = DatabaseContext.db.Client.ToList();
            StorageBo.ItemsSource = DatabaseContext.db.Product.ToList();
            if (curOrder != null)
            {
                _order = curOrder;
                ClientBox.SelectedItem = curOrder.Client;
                StorageBo.SelectedItem = curOrder.Product;
            }
            else
            {
                ClientBox.SelectedIndex = 0;
                StorageBo.SelectedIndex = 0;
            }
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

            if (string.IsNullOrEmpty(TBoxBankName.Text))
                errors.AppendLine("Поле с названием не может быть пустым");
            if (string.IsNullOrEmpty(TBoxBill.Text))
                errors.AppendLine("Поле со счетом не может быть пустым");
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
                _order.ClientId = ((Client)ClientBox.SelectedItem).Id;
                _order.Quantity = Convert.ToInt32(TBoxQuantity.Text);
                PaymentType payment = new PaymentType()
                {
                    BankAccountNumber = Convert.ToInt32(TBoxBill.Text),
                    BankName = TBoxBankName.Text,
                    ClientId = ((Client)ClientBox.SelectedItem).Id,
                    Order = _order,
                };
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
