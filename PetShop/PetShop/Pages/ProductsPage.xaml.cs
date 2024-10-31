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
        Model.User currentUser { get; set; }
        public ProductsPage(Model.User user)
        {
            InitializeComponent();
            OnStart(user);
        }
        private void OnStart(Model.User user)
        {
            currentUser = user;
            ProductsListView.ItemsSource = Model.TradeEntities.GetContext().Product.ToList();
            var FactoriesList = Model.TradeEntities.GetContext().Manufacturers.ToList();
            FactoriesList.Insert(0, new Model.Manufacturers() { Name = "Все производители"});
            FactoryComboBox.ItemsSource = FactoriesList;
            FactoryComboBox.SelectedIndex = 0;
            if (currentUser != null)
            {
                FioTextBlock.Text = $"{currentUser.UserSurname} {currentUser.UserName} {currentUser.UserPatronymic}";
            }
        }
        private void OnUpdate()
        {
            string SearchText = SearchTextBox.Text.ToLower();
            var products = Model.TradeEntities.GetContext().Product.ToList();
            int FullCount = products.Count();
            if (!string.IsNullOrEmpty(SearchText))
            {
                products = products.Where(d => d.ProductType.Name.ToLower().Contains(SearchText)
                || d.Suppliers.Name.ToLower().Contains(SearchText)
                || d.ProductDescription.ToLower().Contains(SearchText)
                || d.ProductCategory.Name.ToLower().Contains(SearchText)
                ).ToList();
            }
            if (FactoryComboBox.SelectedIndex != 0)
            {
                products = products.Where(d => d.ProductManufacturerId == FactoryComboBox.SelectedIndex).ToList();
            }
            if ((bool)OrderUp.IsChecked)
            {
                products = products.OrderBy(d => d.ProductCost).ToList();
            }
            if ((bool)OrderDown.IsChecked)
            {
                products = products.OrderByDescending(d => d.ProductCost).ToList();
            }
            ProductsListView.ItemsSource = products;
            DisplayCountTextBlock.Text = $"Количество выведенных товаров {products.Count()}/{FullCount}";
        }
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Navigation.ActiveFrame.Navigate(new Pages.AddEditPage(null, currentUser));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Navigation.ActiveFrame.RemoveBackEntry();
            Classes.Navigation.ActiveFrame.Navigate(new Pages.AuthPage());
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Navigation.ActiveFrame.Navigate(new Pages.AddEditPage((sender as Button).DataContext as Model.Product, currentUser));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Model.Product selectedProduct = (sender as Button).DataContext as Model.Product;
            if (Model.TradeEntities.GetContext().Orders.Where(d => d.OrderProductId == selectedProduct.ProductId).Any())
            {
                MessageBox.Show("Товар имеется в заказе, удаление невозможно!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            Model.TradeEntities.GetContext().Product.Remove(selectedProduct);
            Model.TradeEntities.GetContext().SaveChanges();
            MessageBox.Show("Товар успешно удален!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            OnUpdate();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnUpdate();
        }

        private void OrderUp_Checked(object sender, RoutedEventArgs e)
        {
            OnUpdate();
        }

        private void OrderDown_Checked(object sender, RoutedEventArgs e)
        {
            OnUpdate();
        }

        private void FactoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnUpdate();
        }
    }
}
