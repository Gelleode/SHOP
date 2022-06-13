using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using SHOP.DBModel;
using Excel = Microsoft.Office.Interop.Excel;

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
                Filter = "xls files(*.xls)|*.xls|All files(*.*)|*.*",
                FileName = $"Order_{order.Id}",
                DefaultExt = ".xls",
                OverwritePrompt = true
            };
            if (saveFileDialog.ShowDialog() == false) return;
            try
            {
                //using (StreamWriter writer =
                //       new StreamWriter(
                //           new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate, FileAccess.Write),
                //           Encoding.UTF8))
                //{
                //    writer.WriteLine($"ТОВАРНЫЙ ЧЕК №{order.Id}");
                //    writer.WriteLine($"Заказчик;;{order.Client.Fullname};Дата заказа;;{order.OrderDate:dd/MM/yyyy}");
                //    writer.WriteLine($"Адрес;;{order.Client.Address};Дата исполнения;;{order.RecieveDate:dd/MM/yyyy}");
                //    writer.WriteLine($"Телефон;;{order.Client.Phone};");
                //    writer.WriteLine($"Наименование товара;;;Количество;Стоимость");
                //    writer.WriteLine($"{order.Product.Title};;;{order.Quantity};{order.Price}");
                //    writer.WriteLine($"Подпись продавца;;_________");
                //}
                File.Create(saveFileDialog.FileName).Close();

                Excel.Application xl = new Excel.Application();

                Excel.Workbook wb = xl.Workbooks.Open(saveFileDialog.FileName);

                Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;

                ws.Cells[1, 1] = $"ТОВАРНЫЙ ЧЕК №{order.Id}";
                ws.Range[ws.Cells[1, 1], ws.Cells[1, 6]].Merge();

                ws.Cells[2, 1] = "Заказчик";
                ws.Range[ws.Cells[2, 1], ws.Cells[2, 2]].Merge();
                ws.Cells[2, 3] = $"{order.Client.Fullname}";
                ws.Cells[2, 4] = "Дата заказа";
                ws.Range[ws.Cells[2, 4], ws.Cells[2, 5]].Merge();
                ws.Cells[2, 6] = $"{order.OrderDate:dd/MM/yyyy}";

                ws.Cells[3, 1] = "Адрес";
                ws.Range[ws.Cells[3, 1], ws.Cells[3, 2]].Merge();
                ws.Cells[3, 3] = $"{order.Client.Address}";
                ws.Cells[3, 4] = "Дата заказа";
                ws.Range[ws.Cells[3, 4], ws.Cells[3, 5]].Merge();
                ws.Cells[3, 6] = $"{order.RecieveDate:dd/MM/yyyy}";

                ws.Cells[4, 1] = "Телефон";
                ws.Range[ws.Cells[4, 1], ws.Cells[4, 2]].Merge();
                ws.Cells[4, 3] = $"{order.Client.Phone}";

                ws.Cells[5, 1] = "Наименование товара";
                ws.Range[ws.Cells[5, 1], ws.Cells[5, 3]].Merge();
                ws.Cells[5, 4] = "Количество";
                ws.Cells[5, 5] = "Стоимость";

                ws.Cells[6, 1] = $"{order.Product.Title}";
                ws.Range[ws.Cells[6, 1], ws.Cells[6, 3]].Merge();
                ws.Cells[6, 4] = $"{order.Quantity}";
                ws.Cells[6, 5] = $"{order.Price}";

                ws.Cells[7, 1] = "Подпись продавца";
                ws.Range[ws.Cells[7, 1], ws.Cells[7, 2]].Merge();

                wb.Close(true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
