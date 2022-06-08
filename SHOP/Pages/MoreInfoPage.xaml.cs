using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
                DGridPage.ItemsSource = DatabaseContext.db.Product.ToList();
            }
        }
    }
}
