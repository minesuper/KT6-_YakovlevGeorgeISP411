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
    /// Логика взаимодействия для ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        public ProductsPage(Model.User user)
        {
            InitializeComponent();
            OnStart(user);

        }
        private void OnStart(Model.User user)
        {
            if (user == null)
            {
                AddProductButton.Visibility = Visibility.Hidden;
            }
            ProductsListView.ItemsSource = Model.TradeEntities.GetContext().Product.ToList();
        }
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.Navigation.ActiveFrame.CanGoBack)
            {
                Classes.Navigation.ActiveFrame.GoBack();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
