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
    /// Логика взаимодействия для NotePage.xaml
    /// </summary>
    public partial class NotePage : Page
    {
        public NotePage()
        {
            InitializeComponent();
            LViewNote.ItemsSource = DatabaseContext.db.Note.ToList();
        }

        private void AddBt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditNotePage(null));
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            var notesForRemoving = LViewNote.SelectedItems.Cast<Note>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {notesForRemoving.Count} элементов?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    DatabaseContext.db.Note.RemoveRange(notesForRemoving);
                    DatabaseContext.db.SaveChanges();
                    MessageBox.Show("Данные успешно удалены", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);

                    LViewNote.ItemsSource = DatabaseContext.db.Note.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DatabaseContext.db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                LViewNote.ItemsSource = DatabaseContext.db.Note.ToList();
            }
        }

        private void MoreBt_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditNotePage((sender as Button).DataContext as Note));
        }
    }
}
