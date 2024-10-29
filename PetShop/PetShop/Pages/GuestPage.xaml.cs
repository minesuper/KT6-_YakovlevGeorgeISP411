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

namespace PetShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для GuestPage.xaml
    /// </summary>
    public partial class GuestPage : Page
    {
        public GuestPage(Model.User user)
        {
            InitializeComponent();
            OnStart(user);
        }
        private void OnStart(Model.User user)
        {
            ProductsListView.ItemsSource = Model.TradeEntities.GetContext().Product.ToList();
            if (user != null)
            {
                FioTextBlock.Text = $"{user.UserSurname} {user.UserName} {user.UserPatronymic}";
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.Navigation.ActiveFrame.CanGoBack)
            {
                Classes.Navigation.ActiveFrame.GoBack();
            }
        }
    }
}
